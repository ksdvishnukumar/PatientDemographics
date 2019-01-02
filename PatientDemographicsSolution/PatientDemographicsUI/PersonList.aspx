<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeBehind="PersonList.aspx.cs" Inherits="PatientDemographicsUI.PersonList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Demographics - Person List</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row main">
                <div class="main-login main-center">
                    <a href="PersonList.aspx" class="btn btn-primary" role="button">List</a>
                    <a href="CreatePerson.aspx" class="btn btn-info" role="button">Create</a>
                    <h2><b>Person List</b></h2>
                    <br />
                    <div class="container" id="tblPersonList" runat="server">
                    </div>
                </div>
            </div>
        </div>

        <script type="text/javascript">
            $(document).ready(function () {
                $.ajax({
                    type: 'get',
                    url: 'http://localhost:1866/api/Person/0',
                    dataType: 'json',
                    success: function (data) {
                        console.log(data)
                        var table = BuildTable(data);
                        $('#tblPersonList').append(table);
                    },
                    failure: function (data) {
                        alert(data.statusText);
                    },
                    error: function (data) {
                        alert(data.statusText);
                    }
                });
            });

            function BuildTable(mydata) {
                var table = "<table class='table table-bordered table-hover'>";
                table += "<thead>"
                table += "<tr class='btn-primary' style='font-weight:bold;'>";
                table += "<td>Forename</td>";
                table += "<td>Surname</td>";
                table += "<td>DOB</td>";
                table += "<td>Gender</td>";
                table += "<td>Home Number</td>";
                table += "<td>Work Number</td>";
                table += "<td>Phone Number</td>";
                table += "<td>Updated Date</td>";
                table += "<td>Action</td>";
                table += "</tr>";
                table += "</thead>";
                table += "<tbody>"

                var TableRow;
                $.each(mydata, function (index, value) {
                    table += "<tr>";
                    table += "<td>" + value.PersomXML.Forename + "</td>";
                    table += "<td>" + value.PersomXML.Surname + "</td>";
                    table += "<td>" + value.PersomXML.DOB + "</td>";
                    table += "<td>" + value.PersomXML.Gender + "</td>";
                    table += "<td>" + value.PersomXML.TelephoneNumbers.HomeNumber + "</td>";
                    table += "<td>" + value.PersomXML.TelephoneNumbers.WorkNumber + "</td>";
                    table += "<td>" + value.PersomXML.TelephoneNumbers.PhoneNumber + "</td>";
                    table += "<td>" + (value.UpdatedDate != null ? value.UpdatedDate : value.CreatedDate) + "</td>";
                    table += "<td><a href='EditPerson.aspx?PID=" + value.PID + "&type=V' >View</a> | <a href='EditPerson.aspx?PID=" + value.PID + "&type=E' >Edit</a></td>";
                    table += "</tr>";
                });
                table += "</tbody>"
                table += "</table>";
                return table;
            }
        </script>
    </form>
</body>
</html>
