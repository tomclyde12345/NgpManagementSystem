﻿

function AdminLogsDashboard() {
    $.ajax({
        type: 'GET',
        url: '/api/adminlogsaccount/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivityuseraccount tbody').html('');
            $.each(data, function (index, value) {
                $('#logsactivityuseraccount tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });



    $.ajax({
        type: 'GET',
        url: '/api/adminlogscontractor/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivitycontractor tbody').html('');    
            $.each(data, function (index, value) {
                $('#logsactivitycontractor tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });


    $.ajax({
        type: 'GET',
        url: '/api/adminlogsforcontract/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivitycontract tbody').html('');
            $.each(data, function (index, value) {
                $('#logsactivitycontract tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });


    $.ajax({
        type: 'GET',
        url: '/api/adminlogsforpayment/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivitypayment tbody').html('');
            $.each(data, function (index, value) {
                $('#logsactivitypayment tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });



    $.ajax({
        type: 'GET',
        url: '/api/adminlogsprojects/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivityprojects tbody').html('');
            $.each(data, function (index, value) {
                $('#logsactivityprojects tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });



    $.ajax({
        type: 'GET',
        url: '/api/adminlogssched/get',
        headers: {
            "Authorization": "Bearer " + localStorage.getItem('access_token')
        },
        success: function (data) {
            $('#logsactivitysched tbody').html('');
            $.each(data, function (index, value) {
                $('#logsactivitysched tbody').append(
                    '<tr>' +
                    /*          '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +*/
                    '<td>' + '<span class="badge badge-light text-black-50  " style="font-size: 10px;border-radius:40px;">' + moment(value.date).format('MMMM DD YYYY LT') + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.logMessage + '</span>' + '</td>' +
                    '<td>' + '<span style="font-size: 15px;">' + value.name + '</span>' + '</td>' +
                    '<td>' + '<span class="badge badge-info   " style="font-size: 12px;">' + value.roleId + '</span>' + '</td>' +
                    '</tr>'
                );
            });
        },

        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });

}




function TotalCounts() {

    //TOTAL USERS ACCCOUNT COUNT
    $.ajax({
        type: 'GET',
        url: '/api/totalusercount/count',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('access_token')
        },
        success: function (data) {
            //alert(data);
            $('#UserAccountadmincount').text(data);
        },
        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });

    //TOTAL CONTRACTORS COUNT
    $.ajax({
        type: 'GET',
        url: '/api/totalcontractor/count',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('access_token')
        },
        success: function (data) {
            //alert(data);
            $('#Contractoradmincount').text(data);
        },
        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });


    //TOTAL PROJECTS COUNT
    $.ajax({
        type: 'GET',
        url: '/api/totalprojects/count',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('access_token')
        },
        success: function (data) {
            //alert(data);
            $('#Projectsadmincount').text(data);
        },
        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });

    //TOTAL CONTRACT COUNT
    $.ajax({
        type: 'GET',
        url: '/api/totalcontract/count',
        headers: {
            'Authorization': 'Bearer ' + localStorage.getItem('access_token')
        },
        success: function (data) {
            //alert(data);
            $('#Contractsadmincount').text(data);
        },
        //if failed
        error: function (data) {

            // toastr.info("Success")
        }
    });

}



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

     //GET DATA FOR SCHED DYNAMIC FOR EDIT SCHEDULE  VIA MODAL
    $.ajax({
        type: 'GET',
        url: '/api/contractdataforsched/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=contractId]').append('<option value="' + value.contractID + '">' + value.contractorName + '</option>');
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
            {
                "data": "RoleId", "name": "RoleId",
                "render": function (data, type, row) {

                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >NgpAdmin</span>'
                    }

                    return '<span class=" badge bg-secondary text-black" style="font-size:12px;" >' + data + '</span>'

                },
            },
            {
                "data": "Name", "name": "Name",
                "render": function (data, type, row) {

                    return '<span class=" badge bg-info text-white" style="font-size:12px;" >' + data + '</span>'

                },

            },

            {
                "data": null,
                'render': function (data, type, full, meta) {
                    return '<button  style=width:68px;  class=\'btn btn-outline-success editsched d-block btn-sm\' data-id = ' + data.schedID + ' > Edit  <span class="fa fa-edit f-20" >  </span></button>' +
                        '<button  style=width:68px;  class=\'btn btn-outline-danger deletesched d-block btn-sm\' data-id = ' + data.schedID + ' > Delete  <span class="fa fa-trash f-20" >  </span></button>'
                }
            },


        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },




    });



    /// GET DATA FOR DELETE SCHED 

    $('#schedtable').on('click', '.deletesched', function () {
        var id = $(this).attr('data-id');
        var url = '/api/scheddelete/delete/' + schedID;
        $("#ScheduleId").val(id);
        $("#deleteschedModal").modal('show');


    });


    /*  DELETE CONTRACTOR  DELETE DATA AFTER CLICK*/
    $("#btnSchedDelete").click(function () {

        // for deletion
        var st = $("#ContrScheduleIdactorId").val();
        //alert(dept);
        $.ajax({
            type: "DELETE",
            url: "/api/scheddelete/delete/" + st,
            success: function (response) {

                setTimeout(function () {
                    toastr.success("Schedule Successfully Deleted");
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
                $("#deleteschedModal").modal('hide');
            },
            error: function (response) {
                toastr.error("Unable to Delete ");
                //alert(result, result.DepartmentId, result.Name);
            }
        })

    })






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





    //GET DATA ONLY FOR EDIT SCHED GET METHOD 

    $("#schedtable").on('click', '.editsched', function () {
        var id = $(this).attr('data-id');
        var url = '/api/schedget/get/' + id;
        //alert(id);
        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $("#editschedModal").modal('show');
                $('#editschedform').find('input[name="schedID"]').val(data.schedID);
                $('#editschedform').find('input[name="ors_no"]').val(data.ors_no);
                $('#editschedform').find('input[name="ors_date"]').val(data.ors_date);
                $('#editschedform').find('input[name="dv_no"]').val(data.dv_no);
                $('#editschedform').find('input[name="dv_date"]').val(data.dv_date);
                $('#editschedform').find('input[name="lddap_no"]').val(data.lddap_no);
                $('#editschedform').find('input[name="lddap_date"]').val(data.lddap_date);
                $('#editschedform').find('select[name="contractId"]').val(data.contractId);
                $('#editschedform').find('input[name="contractor_name"]').val(data.contractor_name);
                $('#editschedform').find('input[name="roleId"]').val(data.roleId);
                $('#editschedform').find('input[name="userName"]').val(data.userName);

            },
            //if failed
            error: function (data) {
                // console.log(data, data.id, data.name);
                toastr.error("error")
            }
        })
    })
    //PUT DATA ONLY FOR EDIT SCHED GET METHOD 
    $("#UpdateSched").click(function (e) {
        e.preventDefault();
        var data = {

            schedID: $('#editschedform').find('input[name=schedID]').val(),
            ors_no: $('#editschedform').find('input[name=ors_no]').val(),
            ors_date: $('#editschedform').find('input[name=ors_date]').val(),
            dv_no: $('#editschedform').find('input[name=dv_no]').val(),
            dv_date: $('#editschedform').find('input[name=dv_date]').val(),
            lddap_no: $('#editschedform').find('input[name=lddap_no]').val(),
            lddap_date: $('#editschedform').find('input[name=lddap_date]').val(),
            contractId: $('#editschedform').find('select[name=contractId]').val(),
            contractor_name: $('#editschedform').find('input[name=contractor_name]').val(),
            roleId: $('#editschedform').find('input[name=roleId]').val(),
            userName: $('#editschedform').find('input[name=userName]').val(),

        };


        var id = $('#editschedform').find('input[name="schedID"]').val();
        $.ajax({
            type: 'PUT',
            url: '/api/schedput/updatesched/' + id,
            data: data,
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')
            },
            success: function (data) {


                $('#editschedModal').modal('hide');
                //show please wait modal
                /*  $('#pleasewait').modal('show');*/
                //show toastr after 3
                setTimeout(function () {
                    toastr.success("Sched Successfully Updated!");
                    // hide please wait modal
                }, 2000);
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            },
            //if failed
            error: function (data) {
                toastr.error("Error Saving")
            }
        });
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
            {
                "data": "yearestablishedId", "name": "yearestablishedId",
            },
            {
                "data": "RoleId", "name": "RoleId",
                "render": function (data, type, row) {

                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >NgpAdmin</span>'
                    }

                    return '<span class=" badge bg-secondary text-black" style="font-size:12px;" >' + data + '</span>'



                },
            },
            {
                "data": "Name", "name": "Name",
                "render": function (data, type, row) {

                    return '<span class=" badge bg-info text-white" style="font-size:12px;" >' + data + '</span>'



                },

            },
          
        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },




    });
    //GET DATA FOR yearestablishedId DYNAMIC FOR CREATE PAYMENT
    $.ajax({
        type: 'GET',
        url: '/api/yeargetdata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=yearestablishedId]').append('<option value="' + value.id + '">' + value.name + '</option>');
            })
        }
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


    
    //GET DATA FOR YEAR DYNAMIC FOR CREATE CONTRACT 
    $.ajax({
        type: 'GET',
        url: '/api/yeargetdata/get',
        success: function (data) {
            $.each(data, function (index, value) {
                $('select[name=year_established]').append('<option value="' + value.id + '">' + value.name + '</option>');
            })
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
            {
                "data": "RoleId", "name": "RoleId",
                "render": function (data, type, row) {

                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >NgpAdmin</span>'
                    }

                    return '<span class=" badge bg-secondary text-black" style="font-size:12px;" >' + data + '</span>'



                },
            },
            {
                "data": "Name", "name": "Name",
                "render": function (data, type, row) {

                    return '<span class=" badge bg-info text-white" style="font-size:12px;" >' + data + '</span>'



                },

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
            {
                "data": "RoleId", "name": "RoleId",
                "render": function (data, type, row) {

                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >NgpAdmin</span>'
                    }

                    return '<span class=" badge bg-secondary text-black" style="font-size:12px;" >' + data + '</span>'



                },
            },
            {
                "data": "Name", "name": "Name",
                "render": function (data, type, row) {

                    return '<span class=" badge bg-info text-white" style="font-size:12px;" >' + data + '</span>'



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
    
    $("#contractortable").on('click', '.editcontractor', function () {
        var id = $(this).attr('data-id');
        var url = '/api/contractorget/get/' + id;
        //alert(id);
        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $("#editcontractorModal").modal('show');
                $('#editcontractorform').find('input[name="contractorID"]').val(data.contractorID);
                $('#editcontractorform').find('input[name="contractor_name"]').val(data.contractor_name);
                $('#editcontractorform').find('select[name="contractor_type"]').val(data.contractor_type);
                $('#editcontractorform').find('select[name="address_municipality"]').val(data.address_municipality);
                $('#editcontractorform').find('select[name="address_barangay"]').val(data.address_barangay);

            },
            //if failed
            error: function (data) {
                // console.log(data, data.id, data.name);
                toastr.error("error")
            }
        })
    })
     //PUT DATA ONLY FOR EDIT Contractor GET METHOD 
    $("#UpdateRecord").click(function (e) {
        e.preventDefault();
        var data = {

            contractor_name: $('#editcontractorform').find('input[name=contractor_name]').val(),
            contractor_type: $('#editcontractorform').find('select[name=contractor_type]').val(),
            address_municipality: $('#editcontractorform').find('select[name=address_municipality]').val(),
            address_barangay: $('#editcontractorform').find('select[name=address_barangay]').val(),
        };


        var id = $('#editcontractorform').find('input[name="contractorID"]').val();
        $.ajax({
            type: 'PUT',
            url: '/api/contractorput/updatecontractor/' + id,
            data: data,
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('access_token')
            },
            success: function (data) {


                $('#editcontractorModal').modal('hide');
                //show please wait modal
              /*  $('#pleasewait').modal('show');*/
                //show toastr after 3
                setTimeout(function () {
                    toastr.success("Contractor Successfully Updated!");
                    // hide please wait modal
                }, 2000);
                setTimeout(function () {
                    window.location.reload();
                }, 3000);
            },
            //if failed
            error: function (data) {
                toastr.error("Error Saving")
            }
        });
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
                    $("#pleasewaitModal").modal('show');
                    toastr.success('Successsfully Added a Contractor');
                    setTimeout(function () {
                        location.reload();
                        window.location.href = "/Information/Index";
                    }, 2000)
                }, 2000);
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
                "data": "RoleId", "name": "RoleId",
                "render": function (data, type, row) {

                    if (data == "NgpAdmin") {

                        return '<span  class=" badge bg-secondary text-black" style="font-size:12px;" >NgpAdmin</span>'
                    }

                    return '<span class=" badge bg-secondary text-black" style="font-size:12px;" >' + data + '</span>'

                   

                },
            },
            {
                "data": "Name", "name": "Name",
                "render": function (data, type, row) {

                    return '<span class=" badge bg-info text-white" style="font-size:12px;" >' + data + '</span>'



                },

            },
            {
                "data": null,
                'render': function (data, type, full, meta) {
                    return '<button  style=width:68px;  class=\'btn btn-outline-success editcontractor d-block btn-sm\' data-id = ' + data.contractorID + ' > Edit  <span class="fa fa-edit f-20" >  </span></button>' + '<button  class=\'btn btn-outline-danger  deletecontractor d-block btn-sm\' data-id = ' + data.contractorID + ' > Delete  <span class="fa fa-trash f-20" >  </span></button>' 

                }
            },
        


        ],


        "processing": "true",
        "language": {
            "processing": "processing... please wait"
        },

        "fnInitComplete": function (oSettings, json) {
            SearchfilterRole(json);
          /*  SearchfilterContractor(json);*/
        }


   });

   //forsearchfilterforrole
    function SearchfilterRole(json) {
        var filterforrole = $('<select/>').addClass("forsearchdropdownfilterrole ");
        filterforrole.append($('<option/>').attr('value', '').text('Select Filter'));
        var roles = [];
        $(json.data).each(function (index, element) {
            if ($.inArray(element.RoleId, roles) == -1) {
                roles.push(element.RoleId);
                filterforrole.append($('<option/>').attr('value', element.RoleId).text(element.RoleId));
            }
        });
        $("#FilterSearchRole").append(filterforrole).children("select").select2();
        $("#FilterSearchRole").on('change', 'select', function () {
            contractorTbl.column(5).search($(this).val()).draw();
        });
    }


    //forsearchfilterforcontractor
    //function SearchfilterContractor(json) {
    //    var filterforcontractorname = $('<select/>').addClass("forsearchdropdownfiltercontractor ");
    //    filterforrole.append($('<option/>').attr('value', '').text('Select Filter'));
    //    var contractor = [];
    //    $(json.data).each(function (index, element) {
    //        if ($.inArray(element.contractor_name, contractor) == -1) {
    //            contractor.push(element.contractor_name);
    //            filterforcontractorname.append($('<option/>').attr('value', element.contractor_name).text(element.contractor_name));
    //        }
    //    });
    //    $("#FilterSearchContractor").append(filterforcontractorname).children("select").select2();
    //    $("#FilterSearchContractor").on('change', 'select', function () {
    //        contractorTbl.column(1).search($(this).val()).draw();
    //    });
    //}

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


    /// GET DATA FOR DELETE CONTRACTOR 

    $('#contractortable').on('click', '.deletecontractor', function () {
        var id = $(this).attr('data-id');
        var url = '/api/contractordelete/delete/' + id;
        $("#ContractorId").val(id);
        $("#deletecontractorModal").modal('show');


    });


    /*  DELETE CONTRACTOR  DELETE DATA AFTER CLICK*/
    $("#btnContractorDelete").click(function () {

        // for deletion
        var st = $("#ContractorId").val();
        //alert(dept);
        $.ajax({
            type: "DELETE",
            url: "/api/contractordelete/delete/" + st,
            success: function (response) {

                setTimeout(function () {
                    toastr.success("Contractor Successfully Deleted");
                    setTimeout(function () {
                        location.reload();
                    }, 2000)
                }, 1500);
                $("#deletecontractorModal").modal('hide');
            },
            error: function (response) {
                toastr.error("Unable to Delete ");
                //alert(result, result.DepartmentId, result.Name);
            }
        })

    })

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
                    return '<button  class=\'btn btn-info  changephoto d-block btn-sm\' data-id = ' + data.Id + ' > Change Profile <span class="fa fa-image f-20" >  </span></button>' + '<button  class=\'btn btn-primary btn-sm  resetpass \' data-id = ' + data.Id + ' > Reset Password <span class="fa fa-key f-20" >  </span></button>'

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
    $('#usertable').on('click', '.changephoto', function () {
        var id = $(this).attr('data-id');
        var url = '/api/editaccount/geteditaccount/' + id;

        $.ajax({
            type: 'GET',
            url: url,
            success: function (data) {
                $("#changePhotoModal").modal('show');
                $('#changephoto').find('input[name="AccountId"]').val(data.id);
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