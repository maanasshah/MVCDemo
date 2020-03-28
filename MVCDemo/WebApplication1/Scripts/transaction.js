//Load Data in Table when documents is ready
$(document).ready(function () {
    loadData();
    getCategories();
    $('input[type=datetime]').datepicker({  
        dateFormat: "M/dd/yy",  
        changeMonth: true,  
        changeYear: true,  
        yearRange: "-60:+0"  
    }); 
});
function getCategories() {
    $.ajax({
        type: "GET",
        url: "/Home/GetCategories",
        data: "{}",
        success: function (result) {
            var s = '<option value="-1">Please Select a Category</option>';
            for (var i = 0; i < result.Data.length; i++) {
                s += '<option value="' + result.Data[i].CategoryId + '">' + result.Data[i].CategoryName + '</option>';
            }
            $("#categoryDropdown").html(s);
        }
    });
}

//Load Data function
function loadData() {
    $.ajax({
        url: "/Home/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var totalPurchase = 0;
            $.each(result.Data, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id + '</td>';
                html += '<td>' + item.Payee + '</td>';
                html += '<td>' + formatDate(item.PurchaseDate) + '</td>';
                html += '<td>' + (item.Amount).toFixed(2) + '</td>';
                html += '<td>' + item.Memo + '</td>';
                html += '<td>' + item.CategoryId + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a></td>';
                html += '</tr>';

                totalPurchase += item.Amount;
            });
            $('.tbody').html(html);
            $('#totalTran').text(result.Data.length);
            $('#totalAmount').text((totalPurchase).toFixed(2));
            $('#avgAmount').text((totalPurchase / result.Data.length).toFixed(2));
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Transaction ID
function getbyID(Id) {
    $('#Payee').css('border-color', 'lightgrey');
    $('#PurchaseDate').css('border-color', 'lightgrey');
    $('#Amount').css('border-color', 'lightgrey');
    $('#Memo').css('border-color', 'lightgrey');
    $('#categoryDropdown').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Home/GetbyID/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (Id <= 0) {
                $('#rowId').css('display', 'none');
                $('#PurchaseDate').val(defaultDate());
            }
            $('#TransactionId').val(result.Data.Id);
            $('#Payee').val(result.Data.Payee);
            $('#PurchaseDate').val(Id > 0 ? formatDate(result.Data.PurchaseDate) : defaultDate());
            $('#Amount').val(result.Data.Amount);
            $('#Memo').val(result.Data.Memo);
            $('#categoryDropdown').val(Id > 0 ? result.Data.CategoryId : -1);
            $('#tranModal').modal('show');
            $('#btnUpdate').show();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

// function to initalize defualt date.
function defaultDate() {
    return new Date().toLocaleDateString('en-US');
}
// We can use momentj date library. For now i am keeping things simple not using any library
function formatDate(d) {
    console.log(d);
    console.log(new Date());
    console.log(new Date(d));
    var dt = d.toString().replace('/Date(', '').replace(')/', '');
    return (new Date(parseInt(dt)).toLocaleDateString('en-US'));
}

//function for updating transaction's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }

    var tranObj = {
        Id: $('#TransactionId').val(),
        Payee: $('#Payee').val(),
        PurchaseDate: $('#PurchaseDate').val(),
        Amount: $('#Amount').val(),
        Memo: $('#Memo').val(),
        CategoryId: $('#categoryDropdown').val()
    };
    $.ajax({
        url: "/Home/Update",
        data: JSON.stringify(tranObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#tranModal').modal('hide');
            $('#TransactionId').val("");
            $('#Payee').val("");
            $('#PurchaseDate').val(defaultDate());
            $('#Amount').val("");
            $('#Memo').val("");
            $('#categoryDropdown').val(-1);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the controlls
function clearTextBox() {
    $('#TransactionId').val("");
    $('#Payee').val("");
    $('#PurchaseDate').val(defaultDate());
    $('#Amount').val("");
    $('#Memo').val("");
    $('#categoryDropdown').val(-1);
    $('#btnUpdate').hide();
    $('#Payee').css('border-color', 'lightgrey');
    $('#Payee').css('border-color', 'lightgrey');
    $('#PurchaseDate').css('border-color', 'lightgrey');
    $('#Amount').css('border-color', 'lightgrey');
    $('#categoryDropdown').css('border-color', 'lightgrey');
    getbyID(0);
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#Payee').val().trim() == "") {
        $('#Payee').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Payee').css('border-color', 'lightgrey');
    }
    if ($('#PurchaseDate').val().trim() == "") {
        $('#PurchaseDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#PurchaseDate').css('border-color', 'lightgrey');
    }
    if ($('#Amount').val().trim() == "" || $('#Amount').val().trim() <= 0) {
        $('#Amount').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Amount').css('border-color', 'lightgrey');
    }
    if ($('#categoryDropdown').val().trim() < 0) {
        $('#categoryDropdown').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#categoryDropdown').css('border-color', 'lightgrey');
    }
    return isValid;
}