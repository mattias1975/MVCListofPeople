"use strict";

function EditListItem(html_id, edit_url) {
    alert(edit_url)
    $.get(edit_url, function (data, status) {
        $('#' + html_id).replacewith(data);
    });
}