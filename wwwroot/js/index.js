let rowNum = 1;

/*let rowData = "<tr><th scope=\"row\">" + rowNum + "</th><td>" + input + "</td><td>" + output + "</td></tr>";*/

$(document).ready(function () {
    $("#add-button").click(function () {
        tableBody = $("table tbody");
        input = $("#input-arguments").val();
        output = $("#output-arguments").val();
        // add data to table with hidden input
        rowData = "<tr><th scope=\"row\">" + rowNum + "</th><td>" + input + "<input type=\"hidden\" name=\"InputData[]\" value=\"" + input + "\"/></td><td>" +
            output + "<input type=\"hidden\" name=\"OutputData[]\" value=\"" + output + "\"/></td></tr>";
        if (rowNum < 4) {
            tr = $(this).parent();
            tableBody.children().eq(rowNum-1).replaceWith(rowData);
        }
        else {
           
            tableBody.append(rowData);
            
        }
        rowNum++;
    });
});
