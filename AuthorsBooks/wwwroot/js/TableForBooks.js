$(document).ready(function () {
    $("#idBookTable").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[2, 4, 6, 8], [2, 4, 6, 8]],
        "ajax": {
            "url": "/Books/LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
        [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "Publisher", "name": "Publisher", "autoWidth": true },
            { "data": "Name", "name": "Name", "autoWidth": true },
            {
                data: null, render: function (data, type, row) {
                    return '<a class="btn btn-info" href="/Books/Delete/' + row.Id + '">Delete</a>';
                }
            }
          
        ]
    });
});


