
var defaultCode = "public class Solution {\n\tpublic static int Algorithm(int n)\n\t{\n\t\t//Enter code here\n\t\treturn 0;\n\t}\n}";

//let tableSize = 3;

let minTableSize = 3;

function setTableSize(n) {
    if (n <= minTableSize) return minTableSize;
    return n-1;
}


$(document).ready(function () {
    /*
     * set the default code for c#
     */
    //$("#code-input").val(defaultCode);

    // set current row number and table size data
    let rowNum = $("#rowNum").data("name");
    let tableSize = setTableSize(rowNum);

    /*
     * function for modifying/appending table with input/output data
     */
    $("#add-button").click(function () {
        tableBody = $("table tbody");
        input = $("#input-arguments").val();
        output = $("#output-arguments").val();
        $("#input-arguments").val("");
        $("#output-arguments").val("");

        // check for empty fields
        if (input === "" || output === "") return;

        // add data to table with hidden input
        rowData = "<tr><th scope=\"row\">" + rowNum + "</th><td>" + input + "<input type=\"hidden\" name=\"InputData[]\" value=\"" + input + "\"/></td><td>" +
            output + "<input type=\"hidden\" name=\"OutputData[]\" value=\"" + output + "\"/></td><td></td><td><image class=\"delete-row\" src=\"images/delete.png\" " +
            "alt=\"delete\" /></td></tr>";
        if (rowNum <= tableSize) {
            tr = $(this).parent();
            tableBody.children().eq(rowNum-1).replaceWith(rowData);
        }
        else { 
            tableBody.append(rowData);
            tableSize++;
        }
        rowNum++;
        //alert("tableSize: " + tableSize + " rowNum: " + rowNum);
    });

    /*
     * function for reseting textarea to default class and method headers
     */
    $("#reset").click(function () {
        $("#code-input").val(defaultCode);
    })

    /*
    * function for deleting table rows
    */
    $("body").on("click", ".delete-row", function () {

        row = $(this).parent().parent();

        // get the current row's row number
        currentRow = row.find("th").html();

        // get the table body
        tableBody = $("table tbody");

        // push each table row up by one to replace the deleted row
        for (i = currentRow; i < tableSize; i++) {       
            nextRow = tableBody.children().eq(i).html();
            thisRow = tableBody.children().eq(i - 1).html(nextRow);
            thisRow.find("th").html(i); // decrement table row number

        }
        // if table size is greater than minimum table size, delete the last row, otherwise append an empty row
        if (tableSize > minTableSize) {
            $("table tr:last").remove();
            tableSize--;
        } else {
            rowData = "<th scope=\"row\">" + tableSize + "</th><td></td><td></td><td></td><td></td>"
            finalRow = tableBody.children().eq(tableSize - 1).html(rowData);
        }

        rowNum--;

    })

    /*
     * function for causing tab to create 4 spaces
     */
    $("#code-input").keydown(function (e) {
        if (e.keyCode == 9) {
            e.preventDefault();
            // get position of cursor
            let caretPos = document.getElementById("code-input").selectionStart;
            // get text from textarea
            let x = $("#code-input").val();
            // insert tab at cursor position
            $('#code-input').val(x.slice(0, caretPos) + "\t" + x.slice(caretPos));
            // move cursor back to original position

        }
    })
});


