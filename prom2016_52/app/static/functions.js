var csrftoken = $('meta[name=csrf_token]').attr('content');
var myMap, myCircle, radius = 1;
var messageSuccess;
var messageError;
var myClusterer;

function map_focus(p){
    myMap.setCenter(p, 17, {
        checkZoomRange: true
    });

    console.log(p);
}

function show(res) { /// res - str . функция отображает на карте все метки которые прилетают в виде не отпарсеного json'a

    var objects = [];
    var list = "";
    for (var t = 0; t < res.events.length; t++) {
        parsed = JSON.parse(res.events[t]);
        objects[t] = new ymaps.GeoObject({
                geometry: {
                    type: "Point",
                    coordinates: [parsed.latitude, parsed.longitude]
                },
                // Свойства.
                properties: {
                    // Контент метки.
                    iconContent: parsed.name,
                    hintContent: parsed.text,
                    id: parsed.id
                }
            },
            {
                // Опции.
                // Иконка метки будет растягиваться под размер ее содержимого.
                preset: ($("#user").val()==parsed.owner ? 'islands#redStretchyIcon' : 'islands#blackStretchyIcon'),
                // Метку можно перемещать.
                draggable: false

        });



        objects[t].events.add('click', function (e){
            var urll = "/api/event/" + e.get('target').properties.get('id');
            console.log(urll);
            ajax_get_html(urll,
                function (res){
                    console.log(res);
                    var coords = e.get('coords');
                    myMap.balloon.open(coords, {
                        contentBody: res
                    });
                },
                function (error) {
                    messageError.show("Ошибка подключения (AJAX)!");
                    console.error(error);
                });

            function show_point_info(info){
                ajax_get_html("/event_small_info.html",
                function(result){
                     console.log(result);
                     draw(result);
                },

                function(error){
                    console.error(error);
                });

            function draw(text){

            }

            }


        });
          list = list + '<div class="one_mark" style="padding-right: 3px; padding-left: 3px; margin-bottom: 5px; border: 1px solid gray; margin-left: 5px; margin-right: 10px; background-color: #eaeaea">'+'<p  onclick="map_focus(['+parsed.latitude+', '+parsed.longitude+'])"  align="center"  style="margin-bottom: 1px; color: '+($("#user").val()==parsed.owner ? "#ff3300" : "#ffae00" )+ '; cursor:pointer;"> <b>'+parsed.name+'</b></p>'+
                
          '<p style="overflow: auto; margin-bottom: 3px; margin-left: 10px;">Адрес: '+parsed.adr+'</p>'+
          '<p style="overflow: auto; margin-bottom: 3px; padding-left: 10px; background-color: #f4f4f4;">Описание: '+parsed.text+'</p>'+
          '</div>';

    }
    if(list == ''){
        if($("#loggedin").val()=="True"){
            list = "<div class='row columns'>  " +
                "<h5 class='text-center' style='color:#cacaca'><i>У вас пока нет событий</i></h5>  </div>";
        }
        else{
            list = "<div class='row columns'>  " +
            "<h5 class='text-center' style='color:#cacaca'><i>События не найдены</i></h5>  </div>";
        }
    }

    myClusterer.removeAll();
    myClusterer.add(objects);
    myMap.geoObjects.add(myClusterer);
    $("#marks_list").html(list);
}

function MessageBox(id) {
    this.foundation_obj = new Foundation.Reveal($('#' + id));
    this.text_element = $('#' + id + ' #text')[0];
    this.show = function (text) {
        this.text_element.innerHTML = text;
        this.foundation_obj.open();
    }
}

function init() {
    messageSuccess = new MessageBox('modal-success');
    messageError = new MessageBox('modal-error');
}

function map_init(){
    myMap = new ymaps.Map("map",
        {
            center: [55.76, 37.64],
            zoom: 12
        });


    myClusterer = new ymaps.Clusterer({ clusterDisableClickZoom: true , openBalloonOnClick: false});


    myMap.controls.remove('trafficControl');
    myCircle = new ymaps.Circle(
    [],
    {
        balloonContent: "<div>Задайте радиус (км):</div><div><input id='radius' type='number' step='0.1' min='0.1' max='10000' onkeyup='changeRadius()' onchange='changeRadius()'></div><div><input class='button' type='button' value='ОК' onclick='closeRadiusBalloon();'><input class='button' style='margin-left: 3%'type='button' value='Убрать' onclick='closeRadiusBalloon(); hideRadius();'></div>",
        hintContent: "Нажмите левую кнопку мыши для изменения радиуса"
    }, {
        draggable: true,
        fillColor: "#FF4B3377",
        // Цвет обводки.
        strokeColor: "#FF0033",
        // Прозрачность обводки.
        strokeOpacity: 0.8,
        strokeWidth: 4
    });

    myMap.events.add('click', function (e) {
        if (!myCircle.getMap()) {
            var coords = e.get('coords');
            myCircle.geometry.setCoordinates(coords);
            myCircle.geometry.setRadius(radius * 1000);
            myMap.geoObjects.add(myCircle);
        }
        else {
            myMap.geoObjects.remove(myCircle);
        }
    });

    myCircle.events.add('balloonopen', function (e) {
        $('#radius')[0].value = radius;
    });

    myCircle.events.add('balloonopen', function (e) {
        $('#radius')[0].value = radius;
    });

    myMap.events.add('contextmenu', function (e) {
        var coords = e.get('coords');
        function draw(text){
            myMap.balloon.open(coords, {
                contentBody: text +
                    '<input type="hidden" value="'+coords[0]+'" id="latitude">'  +
                    '<input type="hidden" value="'+coords[1]+'" id="longitude">' +
                    '</div>'
            });
            setTimeout(function(){
              $("#inputDate3").datetimepicker({dateFormat:'yy-mm-dd', "firstDay": 1 });
              $("#inputDate4").datetimepicker({dateFormat:'yy-mm-dd', "firstDay": 1 });
            },500);
        }

        function close() {
            if (myMap.balloon.isOpen()) myMap.balloon.close();
        }

        var coords_for_geocoder = coords[1]+','+coords[0];
        $.getJSON('http://geocode-maps.yandex.ru/1.x/?' + $.param({geocode: coords_for_geocoder}) +
            '&format=json&callback=?',
             function(data, textStatus) {
                console.log(data.response.GeoObjectCollection);
                city = data.response.GeoObjectCollection.featureMember[0].
                    GeoObject.metaDataProperty.GeocoderMetaData.
                    AddressDetails.Country.AdministrativeArea.AdministrativeAreaName ;
                adress = data.response.GeoObjectCollection.featureMember[0].
                    GeoObject.metaDataProperty.GeocoderMetaData.text;
                $.ajax({
                    url: "/api/add_event",
                    type: "GET",
                    assync:true,
                    data:{
                        'city': city,
                        'adress': adress

                    },
                    dataType: "html",
                    success: function(res){
                        console.log(res);
                        draw(res);

                    },
                    error: function(error){
                        console.error(error);
                    }
                });

            }
        );

    });


    if($("#loggedin").val()=="True")
        formData = {"owner": $("#user").val()};
    else
        formData = {"owner": null};

    ajax_get_json('/api/search_event', JSON.stringify({jsonData: formData}),
        function (res) { show(res); },
        function(error){ messageError.show("Ошибка подключения (AJAX)!"); console.error(error); }
    );


}


function small_map_init(coords, zoom){
    myMap = new ymaps.Map("map",
        {
            center: coords,
            zoom: zoom
        });

    object = new ymaps.GeoObject({
                geometry: {
                    type: "Point",
                    coordinates: [coords[0], coords[1]]
                }
            },
            {
                // Опции.
                // Иконка метки будет растягиваться под размер ее содержимого.
                preset: 'islands#blackStretchyIcon',
                // Метку можно перемещать.
                draggable: false

        });
    myMap.geoObjects.add(object);
    myMap.controls.remove('trafficControl');
}


function changeRadius() {
    radius = Math.min(Math.max($('#radius')[0].value, 0.1), 10000);
    myCircle.geometry.setRadius(radius * 1000);
}

function closeRadiusBalloon() {
    myCircle.balloon.close();
}

function hideRadius() {
    myMap.geoObjects.remove(myCircle);
}

    function submitAddMarkForm() {
    var formData = {
        "name": $("#name").val(),
        "city": $("#city").val(),
        "desc": $("#desc").val(),
        "tags": $("#tags").val(),
        "latitude":$("#latitude").val(),
        "longitude":$("#longitude").val(),
        "adr" : $("#adr").val()

    };

    ajax_get_json('/api/add_event', JSON.stringify({jsonData: formData}),
        function (res) {
            //TODO : обрабатывать и выводить сообщение (res.jsonData)
            switch (res.code) {
            case 0:
                alert(res.result);
                myMap.balloon.close();
                formData = {"owner": $("#user").val()};
                ajax_get_json('/api/search_event', JSON.stringify({jsonData: formData}),
                    function (res) { console.log(res); show(res); },
                    function(error){ messageError.show("Ошибка подключения (AJAX)!"); console.error(error); }
                );
                break;
            case 1:
                alert(res.result);
                break;
            default:
                alert(res.result);
            }
            console.log(res);

        },

        function(error){
            messageError.show("Ошибка подключения (AJAX)!");
            console.error(error);
        }
    );
}

function VisitEvent(t){
    var formData={
        "id":t
    };
    ajax_get_json('/api/event/visit_event', JSON.stringify({jsonData: formData}),
        function(res){
            console.log(res);
        },
        function(error){
            messageError.show("Ошибка подключения (AJAX)!");
            console.error(error);
        }
    );
}

function CommentEvent(t, b) {
    var formData = {
        "id": t,
        "text": $("#body").val()
    };
    ajax_get_json('/ref/event/'+String(t)+'/', JSON.stringify({jsonData: formData}),
        function(res){
            switch(res.code){
            case 0:
                $(".comments").append( "<div class='row'><div class='medium-10 columns'> <div class='callout secondary'> <div class='row'> <div class='medium-12 columns'><a href='/user/"+b+"'>  <p class='text-left' style='color: #ffae00'>"+b+"</p></a> <p>"+formData['text']+" </p> </div> </div> </div> </div></div>" );
                $('textarea[name=body]').val('')
                break;
            case 1:
                messageError.show(res.status);
                break;
            case 2:
                break;
            default:
                alert(res.result);
            }
        },
        function(error){
            messageError.show("Ошибка подключения (AJAX)!");
            console.error(error);
        }
    );
}

function getRadius() {
    $('#radius')[0].value = radius;
}

function submitSearchForm() {
    var formData = {
        "name": $("#name").val(),
        "city": $("#city").val(),
        "tags": $("#tags").val(),
        "time" : $("#inputDate1").val()
    };

    if (myCircle.getMap()) {
        var coords = myCircle.geometry.getCoordinates();
        var radius = myCircle.geometry.getRadius();
        formData.x = coords[0];
        formData.y = coords[1];
        formData.r = radius;
    }

    $.ajax({
        type: "GET",
        url: "http://geocode-maps.yandex.ru/1.x/",
        data:{
        'format':'json',
        'geocode':'37.611,55.758'
        },
        dataType:"JSON",
        error: function(xhr) {
            console.error(xhr);
        },
        success: function(html) {
            console.log(html);
        }
    });

    ajax_get_json('/api/search_event', JSON.stringify({jsonData: formData}),
        function (res) {
            console.log(res);
            show(res);
        },

        function(error){
            messageError.show("Ошибка подключения (AJAX)!");
            console.error(error);
        }
    );
}
    this.remove = function () {
        this.map.geoObjects.remove(this.yobject);
    };

function simplemap_init () {
    // Создание экземпляра карты и его привязка к контейнеру с
    // заданным id ("map").
    myMap = new ymaps.Map('map', {
        // При инициализации карты обязательно нужно указать
        // её центр и коэффициент масштабирования.
        center: [55.76, 37.64], // Москва
        zoom: 10
    }, {
        searchControlProvider: 'yandex#search'
    });

}