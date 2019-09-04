function ajax_get_html(url, suc, err)
{
    $.ajax({
        url: url,
        type: "GET",
        dataType: "html",
        success: function(res){
            suc(res);
        },
        error: function(error)
        {
            err(error);
        }
    });
}


function ajax_get_json(url, request, suc, err)
{
    $.ajaxSetup({
        beforeSend: function(xhr, settings) {
            if (!/^(GET|HEAD|OPTIONS|TRACE)$/i.test(settings.type) && !this.crossDomain) {
                xhr.setRequestHeader("X-CSRFToken", csrftoken)
            }
        }
    });

    $.ajax({
        url: url,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: request,
        dataType: 'json',
        success: function(res){
            suc(res);
        },
        error: function(error)
        {
            err(error);
        }
    });
}
