
$("#addSalesDtls").click(function () {
    createRowForSales();

});
var index = 0;
 var gTotal = 0.0;
function createRowForSales() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#SalesDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='SalesDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";
    var productId = "<td> <input type='hidden' id='ProductId" + index + "'  name='SalesDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' />" + selectedItem.ProductId + "</td>";
    var quantity = "<td> <input type='hidden' id='Quantity" + index + "'  name='SalesDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "' />" + selectedItem.Quantity + "</td>";
    var unitPrice = "<td> <input type='hidden' id='UnitPrice" + index + "'  name='SalesDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' />" + selectedItem.UnitPrice + "</td>";
    var totalPrice = "<td> <input type='hidden' id='TotalPrice" + index + "'  name='SalesDetailses[" + index + "].TotalPrice' value='" + selectedItem.TotalPrice + "' />" + selectedItem.TotalPrice + "</td>";
    gTotal = gTotal + parseFloat(selectedItem.TotalPrice);
    var newRow = "<tr>" + indexTd + slTd + productId +quantity + unitPrice + totalPrice + " </tr>";

    $("#SalesDetailsTable").append(newRow);
    $("#Quantity").val("");
    $("#UnitPrice").val("");
    $("#TotalPrice").val("");
    $("#GrandTotal").val(gTotal);



}


function getSelectedItem() {
    var productId = $("#ProductId").val();
    //var name = $("#Name").val();
    var quantity = $("#Quantity").val();
    var unitPrice = $("#UnitPrice").val();
    var totalPrice = $("#TotalPrice").val();

    var item = {
        "ProductId": productId,
        //"Name": name,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice
    };
    return item;
}

function calculatePrice() {
    var total = 0;
    $("#TotalPrice").val(total);
    var quantity = parseInt($("#Quantity").val());
    var unitPrice = parseInt($("#UnitPrice").val());
    if (quantity != null && unitPrice != null) {
        var total = quantity * unitPrice;
        $("#TotalPrice").val(total);
    }
}

function calculateDue() {
    var due = 0;
    $("#Due").val(due);
    var grandTotal = parseFloat($("#GrandTotal").val());
    var paid = parseFloat($("#Paid").val());
    var due = grandTotal - paid;
    $("#Due").val(due);
    $("#GrandTotal").val(grandTotal);
}
