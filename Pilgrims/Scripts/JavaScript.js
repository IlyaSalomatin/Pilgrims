
//var Human = {};

$("#add").click(
    function () {        
        document.location.replace("/Home/AddAndCorrect");
        //$("#update").val("Add");
        //$("#res").load("/Home/AddAndCorrect");
    }
 );


$("#correct").click(function () {
    $("#res").load("/Home/AddAndCorrect");
    $.ajax({
            url: "/api/values/" + $("#idHuman").val(),
            //url: "/api/values/two/",
            type: "GET",
            success: function (data) {
                $("#ID").val(data.ID);
                $("#Name").val(data.Name);
                $("#SecondName").val(data.SecondName);
                $("#Birthday").val(data.Birthday);
                $("#Planet").val(data.Planet);
            }
        });
});
    
 

$("#back").click(
    function () {
        document.location.replace("/Home/Index");
        //location.href = "http://localhost:57363/Home/Index";
        //document.location.href = "https://www.youtube.com/?gl=UA&hl=ru";       
    }
 );

$("#ollList").click(function () {
    $.ajax({
        url: "/api/values",
        type: "GET",
        success: function (data) {
            //console.dir(data);
            var res = "";
            for (var i = 0; i < data.length; i++) {
                res += data[i].Name + " " + data[i].SecondName + " [id-"+data[i].ID+"]<hr />";
            }
            $("#res").html(res);
        }
    });
});

//$("#ollList").click(function () {
//    $("#res").load("/Home/Resalt");
//    }

//);

$("#search").click(function () {
   // console.log("gogo");
    $.ajax({
        url: "/api/values/" + $("#idHuman").val(),
        type: "GET",
        success: function (data) {
            console.dir(arguments);
            $("#res").html("ID - " + data.ID + "<br/>" + "Name :" + data.Name + "<br/>" + "Second Name :" + data.SecondName + "<br/>" + "Birthday :" + data.Birthday + "<br/>" + "Planet :" + data.Planet + ".");
        }
    });
});

$("#delete").click(function () {
    $.ajax({
        url: "/api/values/" + $("#idHuman").val(),
        type: "DELETE",
        success: function (data) {
            $("#info").val(data);
        }
    });
});

//$("#FormOne").submit(function (event) {
//    // Отключаем обычную отправку формы
//    event.preventDefault();
//    $.ajax({
//        url: "/api/values/",
//        type: "POST",
//        data: {
//            ID: $("#ID").val(),
//            Name: $("#Name").val(),
//            SecondName: $("#SecondName").val(),
//            Birthday: $("#Birthday").val(),
//            Planet: $("#Planet").val(),
//        },
//        success: function (data) {
//            $("#infobox").load(data);
//        }
//    });
//});

//$("#FormOne").submit(function (event) {
//    // Отключаем обычную отправку формы
//    event.preventDefault();
//    var p = {
//        ID: $("#ID").val(),
//        Name: $("#Name").val(),
//        SecondName: $("#SecondName").val(),
//        Birthday: $("#Birthday").val(),
//        Planet: $("#Planet").val(),
//    };
//    $.ajax({
//        url: "/api/values/",        
//        type: "POST",
//        data: JSON.stringify(p),
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            $("#infobox").load(data);
//        }
//    });
//});

$("#plus").click(function () {
    $.ajax({
        url: "/api/values/",
        type: "POST",
        data: {
            ID: $("#ID").val(),
            Name: $("#Name").val(),
            SecondName: $("#SecondName").val(),
            Birthday: $("#Birthday").val(),
            Planet: $("#Planet").val(),
        },
        success: function (data) {
            $("#infobox").val(data);
        }
    });
});

$("#update").click(function () {    
    $.ajax({
        url: "/api/values/",
        type: "PUT",
        data: {
            ID: $("#ID").val(),
            Name: $("#Name").val(),
            SecondName: $("#SecondName").val(),
            Birthday: $("#Birthday").val(),
            Planet: $("#Planet").val(),
        },
        success: function (data) {
            $("#infobox").val(data);
        }
    });
});