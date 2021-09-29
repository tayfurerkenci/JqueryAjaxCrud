﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#loaderbody").addClass('hide');

    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hide');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hide');
    });
});

showInPopup = (url, title) => {
    $.ajax({
        type: "GET",
        url: url,
        success: function (response) {
            $('#form-modal .modal-body').html(response);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
        }
    })
}

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: "POST",
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');
                    $('#view-all').html(res.html);
                    $.notify('Başarı bir şekilde gerçekleştirildi', { globalPosition: 'top center', className:'success' });
                }
                else
                {
                    $('#form-modal .modal-body').html(res.html);

                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    } catch (e) {
        console.log(e);
    }

    // to prevent form submit event
    return false;
}

jQueryAjaxDelete = form => {
    if (confirm("Bu kategoriyi silmek istediğinize emin misiniz?")) {
        try {
            $.ajax({
                type: "POST",
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all').html(res.html);
                    $.notify('Başarı bir şekilde silindi', { globalPosition: 'top center', className:'success' });

                },
                error: function (err) {
                    console.log(err);
                }
            })
        } catch (e) {
            console.log(e);
        }
    }
    // to prevent form submit event
    return false;
}

