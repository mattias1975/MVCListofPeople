"use strict";

function EditListItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditItem(html_id, person_id, edit_url) {
    //console.log($("#name" + person_id).val());
    var person = {
        Id: person_id,
        Name: $('#name' + person_id).val(),
        Phone: $('#phone' + person_id).val(),
        City: $('#city' + person_id).val()
    }

    //console.log(name);
    //console.log(person);
    $.post(edit_url,
        {
            person: person
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);

        });

};
function Createperson(create_url) {
    var person = {
        Name: $('#Name').val(),
        Phone: $('#Phone').val(),
        City: $('#City').val()
    }

    //ajax post
    $.post(create_url,
        {
            person: person
        }
        , function (data, status) {

            $("#peoplelist").append(data);
        });



    // inject respone person in list "id:peoplelist"

}

function DeleteItem() {
    $(document).ready(function () {
        $("button").click(function () {
            $("#Model.id").empty();
        });
    });






    //console.log(name);
    //console.log(person);
    $.post(edit_url,
        {
            person: person
        }
        , function (data, status) {
            $('#' + html_id).replaceWith(data);

        });

};





 //{
 //           Id: person_id,
 //           Name: $("name+" + person_id).val(),
 //           Phone: $("phone+" + person_id).val(),
