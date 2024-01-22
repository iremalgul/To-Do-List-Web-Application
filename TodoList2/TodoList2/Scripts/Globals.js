function postAjaxRequest(url, model, okFunction) {
    $.ajax({
        data: model,
        url: url,
        type: 'POST',
        dataType: 'json',
        success: function (response) {
            okFunction(response);
        }
    });
}