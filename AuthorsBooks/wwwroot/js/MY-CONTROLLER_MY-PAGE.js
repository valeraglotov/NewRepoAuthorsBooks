$(document).ready(function () {
    $("#example").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[2, 4, 6, 8], [2, 4, 6, 8]],
        "ajax": {
            "url": "/Home/LoadData",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs":
        [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "LastName", "name": "LastName", "autoWidth": true },
            { "data": "FirstName", "name": "FirstName", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {
                    return '<a class="btn btn-info" href="/Home/Edit/' + full.Id + '">Edit</a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<a class="btn btn-info" href="/Home/Delete/' + row.Id + '">Delete</a>';
                }
            }
        ]
    });
});

//function DeleteData(CustomerID) {
//    if (confirm("Are you sure you want to delete ...?")) {
//        Delete(CustomerID);
//    }
//    else {
//        return false;
//    }
//}

//function Delete(CustomerID) {
//    var url = '@Url.Content("~/")' + "Home/Delete";

//    $.post(url, { ID: CustomerID }, function (data) {
//        if (data) {
//            oTable = $('#example').DataTable();
//            oTable.draw();
//        }
//        else {
//            alert("Something Went Wrong!");
//        }
//    });
//}