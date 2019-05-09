"use strict";

function EditListItem(html_id, edit_url) {
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function SaveEditItem(html_id, person_id, edit_url) {
    console.log($("name+" + person_id).val());
    var person = {
        Id: person_id,
        Name: $("name+" + person_id).val(),
        Phone: $("phone+" + person_id).val(),
        City: $("City+" + person_id).val()
    }
    console.log(person);
    $.post(edit_url,
        {
            person: person
        }
        , function (data, status) {
        $('#' + html_id).replaceWith(data);

    });
};

/*
 {
            Id: person_id,
            Name: $("name+" + person_id).val(),
            Phone: $("phone+" + person_id).val(),
            City: $("City+" + person_id).val()
        }
 */