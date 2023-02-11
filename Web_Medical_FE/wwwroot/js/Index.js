document.getElementById("btn-submit").addEventListener("click", async (event) => {
    event.preventDefault();

    var form = document.getElementById("form");
    var formData = new FormData(form);



    console.log(formData)
    fetch(`/Auth/CheckEmailPassword?Email=${formData.get("Email")}&Password=${formData.get("Password")}`)
        .then(response => response.json())
        .then(data => {
            if (!data) {
                document.querySelector("#passHelp").innerHTML = "Password is wrong!";
            }
            else {
                fetch("/Auth/Sukses")
                    .then(response => response.text())
                    .then(data => {
                        console.log(data)
                        document.getElementById("modal_body_sm").innerHTML = data;
                        document.getElementById("modal_sm").style.display = "block";
                        setTimeout(function () {
                            window.location.reload();
                        }, 3000);


                    });
            }
        });
    //fetch("/Auth/CheckEmailPassword", {
    //    method: "POST",
    //    headers: {
    //        "Content-Type": "application/json"
    //    },
    //    body: JSON.stringify(data)
    //})
    //    .then(response => response.json())
    //    .then(respon => {
    //        var data = respon;
    //        if (data.success) {
    //            console.log(respon)
    //        }

    //        else {
    //            console.log(respon)

    //        }
    //    });

});


                                                        //var isValid = false;
                                                        //$().ready(function () {
                                                        //    //$("#addTindakanMed").validate({
                                                        //    //    errorClass: "text-danger is-invalid",
                                                        //    //    rules: {
                                                        //    //        Email: {
                                                        //    //            required: true,
                                                        //    //            minlength: 2
                                                        //    //        }

                                                        //    //    },
                                                        //    //    messages: {
                                                        //    //        Name: {
                                                        //    //            required: "Plese fill in",
                                                        //    //            minlength: "Please at least 2 characters"
                                                        //    //        }

                                                        //    //    },

                                                        //    //    submitHandler: function (form) {

                                                        //    //        var dataForm = $(form).serialize();



                                                        //    //        submitForm(dataForm);

                                                        //    //    }
                                                        //    //});


                                                        //    $("#btn-submit").click(function(e){
                                                        //        e.preventDefault();
                                                        //        debugger;
                                                        //        var dataForm = $("#form").serialize();

                                                        //        $.ajax({
                                                        //            debugger;
                                                        //            url: "/Auth/CheckEmailPassword",
                                                        //            data: dataForm,
                                                        //            method: "get",
                                                        //            dataType: "json",
                                                        //            success: function (respon) {
                                                        //                debugger;
                                                        //                var data = respon;
                                                        //                $("#modal_lg").modal("hide");
                                                        //                if (data.success) {

                                                        //                    $("#modal-body-sm").empty();
                                                        //                    $("#modal-body-sm").load("/ProfilLayout/Sukses");
                                                        //                    $("#modal_sm").modal("show");
                                                        //                    window.location.reload();

                                                        //                }
                                                        //                else {

                                                        //                    $("#modal-body-sm").empty();
                                                        //                    $("#modal-body-sm").load("/ProfilLayout/Gagal");
                                                        //                    window.location.reload();
                                                        //                    $("#modal_sm").modal("show");
                                                        //                }


                                                        //            }
                                                        //        })
                                                        //    });

                                                        //    function submitForm(dataParam) {

                                                        //        $.ajax({
                                                        //            url: "/Auth/CheckEmailPassword",
                                                        //            data: dataParam,
                                                        //            method: "get",
                                                        //            dataType: "json",
                                                        //            success: function (respon) {
                                                        //                debugger;
                                                        //                var data = respon.dataRespon;
                                                        //                $("#modal_lg").modal("hide");
                                                        //                if (data.success) {

                                                        //                    $("#modal-body-sm").empty();
                                                        //                    $("#modal-body-sm").load("/ProfilLayout/Sukses");
                                                        //                    $("#modal_sm").modal("show");
                                                        //                    window.location.reload();

                                                        //                }
                                                        //                else {

                                                        //                    $("#modal-body-sm").empty();
                                                        //                    $("#modal-body-sm").load("/ProfilLayout/Gagal");
                                                        //                    window.location.reload();
                                                        //                    $("#modal_sm").modal("show");
                                                        //                }


                                                        //            }
                                                        //        })
                                                        //    };
                                                        //    $("#Name").change(function () {
                                                        //        debugger;
                                                        //        $("#validate_Name").text("")
                                                        //        isValid = true;
                                                        //        var nameTindakan = $(this).val();
                                                        //        $.ajax({
                                                        //            url: "/ProfilLayout/CheckTindakanByName",
                                                        //            data: { name: nameTindakan },
                                                        //            dataType: "json",
                                                        //            success: function (respon) {
                                                        //                debugger;
                                                        //                if (respon) {
                                                        //                    $("#validate_Name").text("Name already used");
                                                        //                    $("#validate_Name").addClass("text-danger");
                                                        //                    $("#btn_Submit").addClass("disabled");
                                                        //                    isValid = false;
                                                        //                }
                                                        //                else {
                                                        //                    $("#validate_Name").toggleClass("text-danger", false);
                                                        //                    $("#btn_Submit").removeClass("disabled");
                                                        //                    isValid = true;
                                                        //                }
                                                        //            },
                                                        //            error: function (res) {
                                                        //                debugger;
                                                        //            }
                                                        //        })
                                                        //    });
                                                        //});
