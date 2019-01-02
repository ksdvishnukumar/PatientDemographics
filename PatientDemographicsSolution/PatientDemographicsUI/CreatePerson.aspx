<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="CreatePerson.aspx.cs" Inherits="PatientDemographicsUI.CreatePerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Demographics - Create Person</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" />
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link href="Content/Style.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <script>
        function ValidateMandatoryInput() {
            //Validate Mandatory Field
            var InputField = 'forename,T;surname,T;gender,S'
            var sp_Ctrl = InputField.split(';');
            var sp_CtrlDet = "";
            for (var i = 0; i < sp_Ctrl.length; i++) {
                sp_CtrlDet = sp_Ctrl[i].split(',')
                if (sp_CtrlDet[1].trim().toUpperCase() == "T") {
                    if (document.getElementById(sp_CtrlDet[0]).value.trim() == "") {
                        alert(sp_CtrlDet[0] + " can not be blank.")
                        return false;
                    }
                }
                else {
                    if (document.getElementById(sp_CtrlDet[0]).selectedIndex == 0) {
                        alert("Select item from the " + sp_CtrlDet[0] + " field.")
                        return false;
                    }
                }
            }

            //Validate CharLength            
            var len = document.getElementById('forename').value.trim().length
            if (len < 3 || len > 50) {
                alert("Forename value can not be less than 3 and more than 50 characters length")
                return false;
            }

            len = document.getElementById('surname').value.trim().length
            if (len < 2 || len > 50) {
                alert("Surname value can not be less than 2 and more than 50 characters length")
                return false;
            }

            return true;
        }

        $(function () {
            $("#dob").datepicker();
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row main">
                <div class="main-login main-center">
                    <a href="PersonList.aspx" class="btn btn-primary" role="button">List</a>
                    <a href="CreatePerson.aspx" class="btn btn-info" role="button">Create</a>
                    <h2><b>Create Person</b></h2>
                    <br />
                    <%--<form class="" method="post" action="#">--%>
                    <div class="form-group">
                        <label for="forename" class="cols-sm-2 control-label">Forename</label>
                        <div class="cols-sm-6">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-user fa" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="forename" id="forename" required placeholder="Enter your Forename" />
                            </div>
                        </div>
                        <div>
                            &nbsp;
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="surname" class="cols-sm-2 control-label">Surname</label>
                        <div class="cols-sm-6">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-envelope fa" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="surname" id="surname" required placeholder="Enter your Surname" />
                            </div>
                        </div>
                        <div>
                            &nbsp;
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="dob" class="cols-sm-2 control-label">DOB</label>
                        <div class="cols-sm-6">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-users fa" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="dob" id="dob" placeholder="Enter your DOB in MM/DD/YYYY format" />
                            </div>
                        </div>
                        <div>
                            <asp:RegularExpressionValidator runat="server" ForeColor="Red" ControlToValidate="dob" ID="DateValidator"
                                ValidationExpression="((0[1-9]|1[0-2])\/((0|1)[0-9]|2[0-9]|3[0-1])\/((19|20)\d\d))$"
                                ErrorMessage="Invalid date format." />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="gender" class="cols-sm-2 control-label">Gender</label>
                        <div class="cols-sm-3">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <select runat="server" class="form-control" name="gender" id="gender" required>
                                    <option>Select</option>
                                    <option>Male</option>
                                    <option>Female</option>
                                    <option>Transgender</option>
                                </select>
                            </div>
                        </div>
                        <div>
                            &nbsp;
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="homenumber" class="cols-sm-2 control-label">Home Number</label>
                        <div class="cols-sm-3">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="homenumber" id="homenumber" maxlength="10" placeholder="Enter your Home Number" />
                            </div>
                        </div>
                        <%--<div >
                        </div>--%>
                    </div>

                    <div class="form-group">
                        <label for="worknumber" class="cols-sm-2 control-label">Work Number</label>
                        <div class="cols-sm-3">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="worknumber" id="worknumber" maxlength="10" placeholder="Enter your Work Number" />
                            </div>
                        </div>
                        <%--<div >
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                ControlToValidate="worknumber" ErrorMessage="Not a valid Work number"
                                ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                        </div>--%>
                    </div>

                    <div class="form-group">
                        <label for="phonenumber" class="cols-sm-2 control-label">Phone Number</label>
                        <div class="cols-sm-3">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock fa-lg" aria-hidden="true"></i></span>
                                <input type="text" runat="server" class="form-control" name="phonenumber" id="phonenumber" maxlength="10" placeholder="Enter your Phone Number" />
                            </div>
                        </div>
                        <%--<div >
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                ControlToValidate="phonenumber" ErrorMessage="Not a valid Phone number"
                               ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator> --%>
                    </div>
                </div>

                <div class="form-group">
                    <div class="cols-sm-6 col-sm-push-6">
                        <input type="button" id="btnSave" name="btnSave" class="btn btn-info" value="Save" />
                        <input type="button" id="btnClear" name="btnClear" class="btn btn-info" value="Clear" />
                        <%--<asp:Button runat="server" ID="btnSave" name="btnSave" OnClientClick="return ValidateInput();" OnClick="btnSave_Click" class="btn btn-info" Text="Save" />--%>
                        <%--<asp:Button runat="server" ID="btnClear" name="btnClear" OnClick="btnClear_Click" class="btn btn-info" Text="Clear" />--%>
                    </div>
                </div>
            </div>
        </div>
        <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script type="text/javascript">
            $("#btnSave").click(function () {
                if (ValidateMandatoryInput()) {
					if (ValidateOptionalInput()) {
						var sendInfo = {
							Forename: $('#forename').val(),
							Surname: $('#surname').val(),
							DOB: $('#dob').val(),
							Gender: $("#gender").val(),
							TelephoneNumbers:
								{
									HomeNumber: $('#homenumber').val(),
									WorkNumber: $('#worknumber').val(),
									PhoneNumber: $('#phonenumber').val()
								}
						};

						$.ajax({
							type: 'post',
							url: 'http://localhost:1866/api/Person/SavePerson',
							dataType: 'json',
							success: function (data) {
								console.log(data)
								alert(data)
								$("#btnClear").click();
							},
							failure: function (data) {
								alert(data.statusText);
							},
							error: function (data) {
								alert(data.statusText);
							},
							data: sendInfo
						});
					}
                }
            });

            $("#btnClear").click(function () {
                $('#forename').val("");
                $('#surname').val("");
                $('#dob').val("");
                $("#gender")[0].selectedIndex = 0;
                $('#homenumber').val("");
                $('#worknumber').val("");
                $('#phonenumber').val("");
            });

            function ValidateOptionalInput() {
                var parsedNumber;
                if ($('#homenumber').val().trim() != "") {
                    parsedNumber = parseInt($('#homenumber').val());
                    if (isNaN(parsedNumber)) {
                        alert("Home Number can have only Number. It should be 10 digit.")
                        return false;
                    }
                    else {
                        if (parsedNumber.toString().length != 10 && parsedNumber != 0) {
                            alert("Home Number is not a valid number. It should be 10 digit.")
                            return false;
                        }
                    }
                }

                if ($('#worknumber').val().trim() != "") {
                    parsedNumber = parseInt($('#worknumber').val());
                    if (isNaN(parsedNumber)) {
                        alert("Work Number can have only Number. It should be 10 digit.")
                        return false;
                    }
                    else {
                        if (parsedNumber.toString().length != 10 && parsedNumber != 0) {
                            alert("Work Number is not a valid number. It should be 10 digit.")
                            return false;
                        }
                    }
                }

                if ($('#phonenumber').val().trim() != "") {
                    parsedNumber = parseInt($('#phonenumber').val());
                    if (isNaN(parsedNumber)) {
                        alert("Phone Number can have only Number. It should be 10 digit.")
                        return false;
                    }
                    else {
                        if (parsedNumber.toString().length != 10 && parsedNumber != 0) {
                            alert("Phoness Number is not a valid number. It should be 10 digit.")
                            return false;
                        }
                    }
                }

                return true;
            }
        </script>
    </form>
</body>
</html>
