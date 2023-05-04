
function Account() {
   
    $("#usertable").DataTable({
        "ajax": {
            "url": "/Account/GetUserDatatable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",
        "order": [[1, "desc"]],

        "columns": [
            {
                "data": "Id", "name": "Id", "className": "hideThis",
            },
            {
                "data": "Name", "name": "Name",
            },
            {
                "data": "Email", "name": "Email",
            },
            {
                "data": "UserName", "name": "UserName",
            },
            {
                "data": "RoleID", "name": "RoleID",
            },
            {
                "data": "RoleID", "name": "RoleID",
                "render": function (data, type, row) {
                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-success text-white" style="font-size:12px;" >Admin</span>'
                    }

                    return '<span  class=" badge bg-primary text-white" style="font-size:12px;" >User</span>'

                },
            },
           
           
        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },

        "fnInitComplete": function (oSettings, json) {

        }


    });
}