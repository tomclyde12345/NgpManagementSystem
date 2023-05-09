
function Sched() {


    //GET DATA FOR SCHED DYNAMIC FOR CREATE SCHEDULE 
    $.ajax({
        type: 'GET',
        url: '/api/contractdataforsched/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=ContractId]').append('<option value="' + value.contractID + '">' + value.contractorName + '</option>');
            })
        }
    });




    //SERVERSIDE DATATABLE FOR payments
    $("#schedtable").DataTable({
        "ajax": {
            "url": "/Sched/GetSchedTable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",


        "columns": [

            {
                "data": "schedID", "name": "schedID", "className": "hideThis"
            },
            {
                "data": "ors_no", "name": "ors_no",
            },
            {
                "data": "ors_date", "name": "ors_date",
            },
            {
                "data": "dv_no", "name": "dv_no",
            },
            {
                "data": "dv_date", "name": "dv_date",
            },
            {
                "data": "lddap_no", "name": "lddap_no",
            },
            {
                "data": "lddap_date", "name": "lddap_date",
            },
            {
                "data": "contractor_name", "name": "contractor_name",
            },

        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },




    });


    //SAVINGR SCHED ADD SCHED
    $("#schedcreate").validate({
        rules: {
            ContractId: {
                required: true,
            },
            ors_no: {
                required: true,
            },
            ors_date: {
                required: true,
            },
            dv_no: {
                required: true,
            },
            dv_date: {
                required: true,
            },
            lddap_no: {
                required: true,
            },
            lddap_date: {
                required: true,
            },
           
          

        },
        errorClass: "validationerror",
        messages: {
            ContractId: {
                required: "Please Seleact a Contract",
            },

            ors_no: {
                required: "Please Input a ors_no",
            },
            ors_date: {
                required: "Please Seleact a ors_date",
            },
            dv_no: {
                required: "Please Input a dv_no",
            },
            dv_date: {
                required: "Please Seleact a dv_date",
            },
            lddap_no: {
                required: "Please Input a lddap_no",
            },
            lddap_date: {
                required: "Please Seleact a lddap_date",
            },
           

        },
        submitHandler: function () {
            if ($("#schedcreate").valid()) {
                var valdata = $("#schedcreate").serialize();

                $.ajax({
                    url: '/api/sched/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Sched');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });

}
function Payment() {


    //SERVERSIDE DATATABLE FOR payments
    $("#paymenttable").DataTable({
        "ajax": {
            "url": "/Payment/GetPaymentTable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",


        "columns": [

            {
                "data": "paymentID", "name": "paymentID", "className": "hideThis"
            },
            {
                "data": "contractorName", "name": "contractorName",
            },
            {
                "data": "num_release", "name": "num_release",
            },
          
        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },




    });

    //GET DATA FOR CONTRACTOR DYNAMIC FOR CREATE PAYMENT 
    $.ajax({
        type: 'GET',
        url: '/api/contractdataforpayment/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=contract_no]').append('<option value="' + value.contractID + '">' + value.contractorName + '</option>');
            })
        }
    });


    //SAVINGR CONTRACT ADD CONTRACT
    $("#paymentcreate").validate({
        rules: {
            contract_no: {
                required: true,
            },
            num_release: {
                required: true,
            },
           
        },
        errorClass: "validationerror",
        messages: {
            contract_no: {
                required: "Please Seleact a Contract",
            },
            num_release: {
                required: "Please Seleact a num_release",
            },
          
        },
        submitHandler: function () {
            if ($("#paymentcreate").valid()) {
                var valdata = $("#paymentcreate").serialize();

                $.ajax({
                    url: '/api/payment/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Payment');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });




}









function Contract() {


    //GET DATA CASCADING DROPDOWN FOR SAVING PROJECT
    $.ajax({
        type: 'GET',
        url: '/api/getmunicipality/municipality/get',
        success: function (data) {
            var html = '<option value="">Select municipalityName</option>';
            $.each(data, function (i, item) {
                html += '<option value="' + item.municipalityId + '">' + item.municipalityName + '</option>';
            });
            $('select[name=location_municipality]').html(html);
            // render divisionsId2 select
            // console log on select change
            $('select[name=location_municipality]').on('change', function () {
                var municipalityId = $('select[name=location_municipality]').val();

                $.ajax({
                    type: 'GET',
                    url: '/api/barangaylist/get/' + municipalityId,
                    success: function (data) {
                        var html = '';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.barangayId + '">' + item.barangayName + '</option>';
                        });
                        console.log(data);
                        $('select[name=location_barangay]').html(html);
                    }
                });
            });
        }
    });


    //SAVINGR CONTRACT ADD CONTRACT
    $("#createcontract").validate({
        rules: {
            moa: {
                required: true,
            },
            contractor_name: {
                required: true,
            },
        },
        errorClass: "validationerror",
        messages: {
            moa: {
                required: "Please Input a moa",
            },
            contractor_name: {
                required: "Select  a Contractor Name",
            },
        },
        submitHandler: function () {
            if ($("#createcontract").valid()) {
                var valdata = $("#createcontract").serialize();
              
                $.ajax({
                    url: '/api/contract/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Contract');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });


    



    //GET DATA FOR CONTRACTOR DYNAMIC FOR CREATE CONTRACT 
    $.ajax({
        type: 'GET',
        url: '/api/contractorgetdata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=contractorName]').append('<option value="' + value.contractor_name + '">' + value.contractor_name + '</option>');
            })
        }
    });



    $("#contracttable").DataTable({
        "ajax": {
            "url": "/Contract/GetContractTable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",


        "columns": [

            {
                "data": "contractID", "name": "contractID", "className": "hideThis"
            },
            {
                "data": "contractorName", "name": "contractorName",
            },
            {
                "data": "location_municipality", "name": "location_municipality",
            },
            {
                "data": "location_barangay", "name": "location_barangay",
            },
            {
                "data": "location_sitio", "name": "location_sitio",
            },
            {
                "data": "area", "name": "area",
            },
            {
                "data": "commodity", "name": "commodity",
            },
            {
                "data": "commodity_type", "name": "commodity_type",
            },

            {
                "data": "survival_rate", "name": "survival_rate",
            },
            {
                "data": "project_name", "name": "project_name",
            },
            {
                "data": "contract_cost", "name": "contract_cost",
            },
            {
                "data": "site_code", "name": "site_code",
            },
            {
                "data": "year_established", "name": "year_established",
            },
            {
                "data": "num_seedlings_planted", "name": "num_seedlings_planted",
            },
            {
                "data": "num_seedlings_survived", "name": "num_seedlings_survived",
            },
            {
                "data": "num_seedlings_replanted", "name": "num_seedlings_replanted",
            },
            {
                "data": "num_seedlings_survived_year1", "name": "num_seedlings_survived_year1",
            },

        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },

     


    });
}


function Project() {

    //SERVERSIDE DATATABLE PROJECT
    $("#projecttable").DataTable({
        "ajax": {
            "url": "/Project/GetProjecttable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",
        "order": [[1, "desc"]],

        "columns": [

            {
                "data": "area", "name": "area",
            },
            {
                "data": "site_code", "name": "site_code"
            },
            {
                "data": "location_municipality", "name": "location_municipality"
            },
            {
                "data": "location_barangay", "name": "location_barangay"
            },
            {
                "data": "year_form", "name": "year_form"
            },
            {
                "data": "penro", "name": "penro"
            },
            {
                "data": "cenro", "name": "cenro"
            },
            {
                "data": "region", "name": "region"
            },


        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },

        "fnInitComplete": function (oSettings, json) {

        }


    });

    //SAVING PROJECT CREATE
    $("#createproject").validate({
        rules: {
            site_code: {
                required: true,
            },
            location_municipality: {
                required: true,
            },
            location_barangay: {
                required: true,
            },
            area: {
                required: true,
            },
            year_form: {
                required: true,
            },
            penro: {
                required: true,
            },
            cenro: {
                required: true,
            },
            region: {
                required: true,
            },
        },
        errorClass: "validationerror",
        messages: {
            site_code: {
                required: "Please Input a site_code",
            },
            location_municipality: {
                required: "Please Select a location_municipality",
            },
            location_barangay: {
                required: "Please Select a location_barangay",
            },
            area: {
                required: "Please Input a area",
            },
            site_code: {
                required: "Please Select a site_code",
            },
            year_form: {
                required: "Please Select a year_form",
            },
            penro: {
                required: "Please Select a penro",
            },
            cenro: {
                required: "Please Select a cenro",
            },
        },
        submitHandler: function () {
            if ($("#createproject").valid()) {
                var valdata = $("#createproject").serialize();

                $.ajax({
                    url: '/api/project/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Project');
                    setTimeout(function () {
                        location.reload();
                        
                    }, 1000)
                }, 1000);
            }
        }
    });





    //GET DATA CASCADING DROPDOWN FOR SAVING PROJECT
    $.ajax({
        type: 'GET',
        url: '/api/getmunicipality/municipality/get',
        success: function (data) {
            var html = '<option value="">Select municipalityName</option>';
            $.each(data, function (i, item) {
                html += '<option value="' + item.municipalityId + '">' + item.municipalityName + '</option>';
            });
            $('select[name=location_municipality]').html(html);
            // render divisionsId2 select
            // console log on select change
            $('select[name=location_municipality]').on('change', function () {
                var municipalityId = $('select[name=location_municipality]').val();

                $.ajax({
                    type: 'GET',
                    url: '/api/barangaylist/get/' + municipalityId,
                    success: function (data) {
                        var html = '';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.barangayId + '">' + item.barangayName + '</option>';
                        });
                        console.log(data);
                        $('select[name=location_barangay]').html(html);
                    }
                });
            });
        }
    });

}




function ContractorAnimation() {



    //GET DATA CASCADING DROPDOWN FOR SAVING CONTRACTOR
    $.ajax({
        type: 'GET',
        url: '/api/getmunicipality/municipality/get',
        success: function (data) {
            var html = '<option value="">Select municipalityName</option>';
            $.each(data, function (i, item) {
                html += '<option value="' + item.municipalityId + '">' + item.municipalityName + '</option>';
            });
            $('select[name=address_municipality]').html(html);
            // render divisionsId2 select
            // console log on select change
            $('select[name=address_municipality]').on('change', function () {
                var municipalityId = $('select[name=address_municipality]').val();

                $.ajax({
                    type: 'GET',
                    url: '/api/barangaylist/get/' + municipalityId,
                    success: function (data) {
                        var html = '';
                        $.each(data, function (i, item) {
                            html += '<option value="' + item.barangayId + '">' + item.barangayName + '</option>';
                        });
                        console.log(data);
                        $('select[name=address_barangay]').html(html);
                    }
                });
            });
        }
    });

    //GET DATA ONLY FOR EDIT Contractor GET METHOD 
    $('#contractortable').on('click', '.editcontractor', function () {
        var id = $(this).attr('data-id');
        var url = '/api/contractor/geteditcontractor/' + id;
        /*    toastr.success(id);*/


        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $('#editcontractorModal').modal('show');
                $('#editcontractorform').find('input[name="contractorID"]').val(data.contractorID);
                $('#editcontractorform').find('input[name="contractor_name"]').val(data.contractor_name);
                $('#editcontractorform').find('select[name="contractor_type"]').val(data.contractor_type);
                $('#editcontractorform').find('select[name="address_municipality"]').val(data.address_municipality);
                $('#editcontractorform').find('select[name="address_barangay"]').val(data.address_barangay);

            }
        })

    });


    /* SAVING EDIT CONTRACTOR POST METHOD*/
    $("#editcontractorform").validate({
        rules: {
            contractor_name: {
                required: true,
            },
            contractor_type: {
                required: true,
            },
          

        },
        errorClass: "tomerror",
        messages: {
            contractor_name: {
                required: "Please Enter Your Name",
            },
           

        },
        submitHandler: function () {
            if ($("#editcontractorModal").valid()) {
                var valdata = $("#editcontractorModal").serialize();
                $('#editcontractorModal').modal('hide');
                $.ajax({
                    url: '/api/savingeditcontractor/post/' + id,
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                //setTimeout(function () {
                //    toastr.success('EDIT SUCCESSFULLY');
                //    setTimeout(function () {
                //        location.reload();
                //    }, 2000)
                //}, 1500);
            }
        }
    });


    //SAVINGR CONTRACTOR CREATE
    $("#contract_main").validate({
        rules: {
            contractor_name: {
                required: true,
            },
            address_municipality: {
                required: true,
            },
            address_barangay: {
                required: true,
            },
            contractor_type: {
                required: true,
            },
        },
        errorClass: "validationerror",
        messages: {
            contractor_name: {
                required: "Please Input a Contractor",
            },
            address_municipality: {
                required: "Please Select a Municipality",
            },
            address_barangay: {
                required: "Please Select a Barangay",
            },
            contractor_type: {
                required: "Please Select a Type",
            },
        },
        submitHandler: function () {
            if ($("#contract_main").valid()) {
                var valdata = $("#contract_main").serialize();
               
                $.ajax({
                    url: '/api/contractor/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Contractor');
                    setTimeout(function () {
                        location.reload();
                        window.location.href = "/Contractor/Index";
                    }, 1000)
                }, 1000);
            }
        }
    });


    //SERVER SIDE DATATABLE SHOW DATA FOR CONTRACTOR
   var contractorTbl = $("#contractortable").DataTable({
        "ajax": {
            "url": "/Contractor/GetContractorTable",
            "type": "POST",
            "datatype": "json", dataSrc: "data"
        },

        "processing": "true",
        "serverSide": "true",
        "serverSide": "true",
        "order": [[1, "desc"]],

        "columns": [
            {
                "data": "contractorID", "name": "contractorID", "className": "hideThis",
            },
            {
                "data": "contractor_name", "name": "contractor_name",
            },
            {
                "data": "address_municipality", "name": "address_municipality",
            },
            {
                "data": "address_barangay", "name": "address_barangay",
            },
            {
                "data": "contractor_type", "name": "contractor_type",
            },
            {
                "data": null,
                'render': function (data, type, full, meta) {
                    return '<button  class=\'btn btn-success  editcontractor d-block btn-sm\' data-id = ' + data.contractorID + ' > Edit  <span class="fa fa-edit f-20" >  </span></button>' 

                }
            },
        


        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },

        "fnInitComplete": function (oSettings, json) {

        }


    });

    //GET DATA FOR ROLE DYNAMIC FOR TYPE CONTRACTOR
    $.ajax({
        type: 'GET',
        url: '/api/roledata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=roleId]').append('<option value="' + value.id + '">' + value.roleName + '</option>');
            })
        }
    });

}
 

function Account() {
   //SERVER SIDE DATATABLE SHOW DATA FOR USER
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
                "data": null,
                'render': function (data, type, full, meta) {
                    return '<button  class=\'btn btn-success btn-sm d-block  edit \' data-id = ' + data.Id + ' > Edit <span class="fa fa-edit f-20" >  </span></button>'
                        +
                        '<button  class=\'btn btn-danger deleteaccount d-block btn-sm\' data-id = ' + data.Id + ' > Delete<span class="fa fa-trash f-20" >  </span></button>' 
                        

                }
            },
            {
                "data": null,
                'render': function (data, type, full, meta) {
                    return '<button  class=\'btn btn-info  photo d-block btn-sm\' data-id = ' + data.Id + ' > Change Profile <span class="fa fa-image f-20" >  </span></button>' + '<button  class=\'btn btn-primary btn-sm  resetpass \' data-id = ' + data.Id + ' > Reset Password <span class="fa fa-key f-20" >  </span></button>'

                }
            },
            {
                "data": "RoleID", "name": "RoleID",
                "render": function (data, type, row) {
                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" stByle="font-size:12px;" >Admin</span>'
                    }

                    return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >User</span>'

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



    //GET DATA FOR ROLE DYNAMIC FOR CREATE ACCOUNT
    $.ajax({
        type: 'GET',
        url: '/api/roledata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=roleId]').append('<option value="' + value.id + '">' + value.roleName + '</option>');
            })
        }
    });
    //GET DATA FOR ROLE DYNAMIC  FOR EDIT ACCOUNT
    $.ajax({
        type: 'GET',
        url: '/api/roledata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=roleID]').append('<option value="' + value.id + '">' + value.roleName + '</option>');
            })
        }
    });

    //GET DATA ONLY FOR EDIT ACCOUNT GET METHOD 
    $('#usertable').on('click', '.edit', function () {
        var id = $(this).attr('data-id');
        var url = '/api/editaccount/geteditaccount/' + id;
        /*    toastr.success(id);*/


        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $('#editAccountModal').modal('show');
                $('#editaccount').find('input[name="id"]').val(data.id);
                $('#editaccount').find('input[name="name"]').val(data.name);
                $('#editaccount').find('input[name="userName"]').val(data.userName);
                $('#editaccount').find('input[name="email"]').val(data.email);
                $('#editaccount').find('select[name="roleID"]').val(data.roleID);

            }
        })
       
      
    });


    //GET DATA CHANGE IMAGE
    $('#usertable').on('click', '.photo', function () {
        var id = $(this).attr('data-id');
        var url = '/api/editaccount/geteditaccount/' + id;

        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $("#changePhotoModal").modal('show');
                $('#changephoto').find('input[name="id"]').val(data.id);
                $('#changephoto').find('input[name="name"]').val(data.name);
                console.log(data.id)

            }
        });

        var url2 = '/api/account/getpics/' + id;

        $.ajax({
            type: 'GET',
            url: url2,

            success: function (data) {
                $('#changephoto').find('input[name="id"]').val(data.id);
                $("#imageshow").empty();
                $("#imageshow").append("<img style='width:155px;height:155px; border-radius: 92px; overflow:hidden' src='" + data.filePath + "' />");
            }
        });

    });




    /// GET DATA FOR DELETE ACCOUNT  IN ACCOUNT TABLE

    $('#usertable').on('click', '.deleteaccount', function () {
        var id = $(this).attr('data-id');
        var url = '/api/accountdelete/getaccountdelete/' + id;
        $("#DeleteAccountId").val(id);
        $("#deleteAccountModal").modal('show');




    });

    //  //GET DATA ONLY FOR  RESET PASSWORD
    $('#usertable').on('click', '.resetpass', function () {
        var id = $(this).attr('data-id');
        var url = '/api/editaccount/geteditaccount/' + id;
        /*    toastr.success(id);*/
        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $('#resetpassModal').modal('show');
                $('#resetpassword').find('input[name="id"]').val(data.id);
                $('#resetpassword').find('input[name="userName"]').val(data.userName);
                $('#resetpassword').find('input[name="password"]').val('');
                $('#resetpassword').find('input[name="name"]').val(data.name);
                $('#resetpassword').find('input[name="email"]').val(data.email);
                $('#resetpassword').find('input[name="roleID"]').val(data.roleID);

            }
        })
    });







    // SAVING CREATE ACCOUNT WITH PICTURE
    $("#createaccount").validate({
        rules: {
            Name: {
                required: true,
            },
            Email: {
                required: true,
            },
            UserName: {
                required: true,
            },
            Password: {
                required: true,
                regex: ("(?=.*?[0-9])(?=.*?[A-Z])(?=.*?[#?!@$%^&*\\-_]).{8,}$")
            },
            roleId: {
                required: true,

            },


        },
        errorClass: "validationerror",
        messages: {
            Name: {
                required: "Please Input a Name",
            },
            Email: {
                required: "Please Input a Email",
            },
            UserName: {
                required: "Please Input a Username",
            },
            Password: {
                required: "Please Input a Password",
                regex: "At least 1 Uppercase,1 Lowercase,1 Special Character, 1 Numeric Character and Minimum of 8 Characters"
            },
            roleId: {
                required: "Please Select a Role",
            },


        },
    });
    $("#createaccount").submit(function (e) {

        e.preventDefault();
        var formData = new FormData(this);
        if ($("#createaccount").valid()) {
            $('#createModal').modal('hide');
            $.ajax({
                type: 'POST',
                url: '/api/addaccount/post',
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {

                    setTimeout(function () {
                        toastr.success("Account Successfully Created");
                        setTimeout(function () {
                            location.reload();
                        }, 2000)
                    }, 1500);
                    $("#createModal").modal('hide');
                },
                error: function (response) {
                    toastr.error("Unable to Delete Dependent in Foreign Key");
                    //alert(result, result.DepartmentId, result.Name);
                }
            });
        }
    })



    /* SAVING EDIT ACCOUNT POST METHOD*/
    $("#editaccount").validate({
        rules: {
            name: {
                required: true,
            },
            userName: {
                required: true,
            },
            email: {
                required: true,
            },
            roleID: {
                required: true,
            },

        },
        errorClass: "tomerror",
        messages: {
            name: {
                required: "Please Enter Your Name",
            },
            userName: {
                required: "Please Enter Your Username",
            },
            email: {
                required: "Please Enter Your Email",
            },
            roleID: {
                required: "Please Select Your RoleID",
            },

        },
        submitHandler: function () {
            if ($("#editaccount").valid()) {
                var valdata = $("#editaccount").serialize();
                $('#editAccountModal').modal('hide');
                $.ajax({
                    url: '/api/savingeditaccount/post/' + id,
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('EDIT SUCCESSFULLY');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });


    /*  DELETE ACCOUNT POST  DELETE DATA AFTER CLICK*/ 
    $("#btnAccounteDelete").click(function () {

        // for deletion
        var st = $("#DeleteAccountId").val();
        //alert(dept);
        $.ajax({
            type: "DELETE",
            url: "/api/accountdelete/getaccountdelete/" + st,
            success: function (response) {

                setTimeout(function () {
                    toastr.success("Account Successfully Deleted");
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
                $("#deleteAccountModal").modal('hide');
            },
            error: function (response) {
                toastr.error("Unable to Delete Dependent in Foreign Key");
                //alert(result, result.DepartmentId, result.Name);
            }
        })

    })

    //CHANGE PROFILE PICTURE SAVING PHOTO
    $("#changephoto").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        if ($("#changephoto").valid()) {
            $('#changePhotoModal').modal('hide');
            $.ajax({
                type: 'POST',
                url: '/api/changephoto',
                data: formData,
                cache: false,
                contentType: false,
                processData: false,
                success: function (response) {

                    setTimeout(function () {
                        toastr.success("Profile Picture Successfully Change");
                        setTimeout(function () {
                            location.reload();
                        }, 2000)
                    }, 1500);
                    $("#changePhotoModal").modal('hide');
                },
                error: function (response) {
                    toastr.error("Unable to Delete Dependent in Foreign Key");
                    //alert(result, result.DepartmentId, result.Name);
                }

            });
        }
    })


    //RESET PASSWORD SAVING FOR USER ACCOUNT
    $("#resetpassword").validate({
        rules: {

            userName: {
                required: true,
            },
            password: {
                required: true,
                regex: ("(?=.*?[0-9])(?=.*?[A-Z])(?=.*?[#?!@$%^&*\\-_]).{8,}$")
            },


        },
        errorClass: "validationerror",
        messages: {

            userName: {
                required: "Please Enter Your Username",
            },
            password: {
                required: "Please Input a Password",
                regex: "At least 1 Uppercase,1 Lowercase,1 Special Character, 1 Numeric Character and Minimum of 8 Characters"
            },


        },
        submitHandler: function () {
            if ($("#resetpassword").valid()) {
                var valdata = $("#resetpassword").serialize();
                $('#resetpassModal').modal('hide');
                $.ajax({
                    url: '/api/resetpassword/postresetpassword/' + id,
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('RESET PASSWORD SUCCESSFULLY');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });

    //SAVINGR ROLE ADD ROLE
    $("#createrole").validate({
        rules: {
            RoleName: {
                required: true,
            },
        },
        messages: {
            RoleName: {
                required: "Please Input a Role",
            },
        },
        submitHandler: function () {
            if ($("#createrole").valid()) {
                var valdata = $("#createrole").serialize();
                $('#createroleModal').modal('hide');
                $.ajax({
                    url: '/api/saverole/post',
                    type: "POST",
                    dataType: 'json',
                    contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                    data: valdata,
                });
                setTimeout(function () {
                    toastr.success('Successsfully Added a Role');
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
            }
        }
    });
}