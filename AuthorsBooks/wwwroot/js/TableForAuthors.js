$(document).ready(function () {
    $("#example").DataTable({
        "processing": true, // for show progress bar
        "serverSide": true, // for process server side
        "filter": true, // this is for disable filter (search box)
        "orderMulti": false, // for disable multiple column at once
        "aLengthMenu": [[2, 4, 6, 8], [2, 4, 6, 8]],
        "ajax": {
            "url": "/Author/LoadData",
            "type": "POST",
            "datatype": "JSON"
        },
        "columnDefs":
        [{
            "targets": [0],
            "visible": true,
            "searchable": false
        }],
        "columns": [
            { "data": "Id", "name": "Id", "autoWidth": true },
            { "data": "LastName", "name": "LastName", "autoWidth": true },
            { "data": "FirstName", "name": "FirstName", "autoWidth": true },
            {
                "render": function (data, type, full, meta) {
                    return '<a class="btn btn-info" href="/Author/EditPage/' + full.Id + '">Edit</a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<a class="btn btn-info" type="button" class="delete" value="delete' + row.Id + '">Delete</a>';
                }
            },
            {
                data: null, render: function (data, type, row) {
                    return '<a class="btn btn-info" href="/Author/ShowAuthorBooks/' + row.Id + '">Show books</a>';

                }
            }
           
            //{
            //    data: null, render: function (data, type, row) {
            //        return '<form asp-action="Delete" data-ajax="true" data-ajax-update="#example">' +
            //            '<button type="submit" class="btn btn-sm btn-danger d-none d-md-inline-block">d</button>';

                        
            //    }
            //}

        //    < form asp - action="Delete" asp - route - id="@customer.Id" data - ajax="true" data - ajax - update="#CustomerList" >
        //<button type="submit" class="btn btn-sm btn-danger d-none d-md-inline-block">
        //Delete
        //</button>
        //</form >
        ]
    });
});

//$('#delete').click(function (e) {
//    e.preventDefault(); // <------------------ stop default behaviour of button
//    var element = this;
//    $.ajax({
//        url: "/Author/Delete",
//        type: "POST",
//        data: JSON.stringify(),
//        dataType: "json",
//        traditional: true,
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            if (data.status == "Success") {
//                alert("Done");
//                $(element).closest("form").submit(); //<------------ submit form
//            } else {
//                alert("Error occurs on the Database level!");
//            }
//        },
//        error: function () {
//            alert("An error has occured!!!");
//        }
//    });
//});


//$('#btnSave').click(function (e) {
//    e.preventDefault(); // <------------------ stop default behaviour of button
//    var element = this;
//    $.ajax({
//        url: "/Author/SaveDetailedInfo",
//        type: "POST",
//        data: JSON.stringify(),
//        dataType: "json",
//        traditional: true,
//        contentType: "application/json; charset=utf-8",
//        success: function (data) {
//            if (data.status == "Success") {
//                alert("Done");
//                $(element).closest("form").submit(); //<------------ submit form
//            } else {
//                alert("Error occurs on the Database level!");
//            }
//        },
//        error: function () {
//            alert("An error has occured!!!");
//        }
//    });
//});

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