
var defaultCode = "public class Solution\n{\n\tpublic static int Algorithm(int n)\n\t{\n\t\t//Enter code here\n\t\treturn 0;\n\t}\n}";

let minTableSize = 3;

function setTableSize(n) {
    if (n <= minTableSize) return minTableSize;
    return n-1;
}

/*
   * show the loading gif until page loads
   */
//$(window).load(function () {
//    
//});


$(document).ready(function () {
    $('#loading').hide();

    // set current row number and table size data
    let rowNum = $("#rowNum").data("name");
    let tableSize = setTableSize(rowNum);

    /*
     * function for modifying/appending table with input/output data
     */
    $("body").on("click", "#add-button", function () {
        var tableBody = $("#data-table tbody");
        var input = $("#input-arguments").val();
        var output = $("#output-arguments").val();
        $("#input-arguments").val("");
        $("#output-arguments").val("");

        // check for empty fields
        if (input === "" || output === "") return;

        // add data to table with hidden input
        var rowData = "<tr><th scope=\"row\">" + rowNum + "</th><td>" + input + "<input type=\"hidden\" name=\"InputData[]\" value=\"" + input + "\"/></td><td>" +
            output + "<input type=\"hidden\" name=\"OutputData[]\" value=\"" + output + "\"/></td><td></td><td><image class=\"delete-row\" src=\"images/delete.png\" " +
            "alt=\"delete\" /></td></tr>";
        if (rowNum <= tableSize) {
            var tr = $(this).parent();
            tableBody.children().eq(rowNum-1).replaceWith(rowData);
        }
        else { 
            tableBody.append(rowData);
            tableSize++;
        }
        rowNum++;
    });

    /*
     * add loading gif when go button is pressed and disabled textarea and add button
     */
    $("body").on("click", "#go", function () {
        $('#loading').show();
        $('#results').hide();
        $("#code-input").prop("readonly", true);
        $("#add-button").prop("disabled", true);
    })

    /*
     * function for reseting textarea to default class and method headers
     */
    $("body").on("click", "#reset", function () {
        $("#code-input").val(defaultCode);
    })

    /*
    * function for deleting table rows
    */
    $("body").on("click", ".delete-row", function () {

        var row = $(this).parent().parent();

        // get the current row's row number
        var currentRow = row.find("th").html();

        

        // get the table body
        var tableBody = $("#data-table tbody");

        // push each table row up by one to replace the deleted row
        for (i = currentRow; i < tableSize; i++) {
            var nextRow = tableBody.children().eq(i).html();
            var thisRow = tableBody.children().eq(i - 1).html(nextRow);
            thisRow.find("th").html(i); // decrement table row number
        }
        // if table size is greater than minimum table size, delete the last row, otherwise append an empty row
        if (tableSize > minTableSize) {
            $("#data-table tr:last").remove();
            tableSize--;
        } else {
            var rowData = "<th scope=\"row\">" + tableSize + "</th><td></td><td></td><td></td><td></td>"
            tableBody.children().eq(tableSize - 1).html(rowData);
        }

        rowNum--;

    })

    /*
     * function for causing tab to create 4 spaces
     */
    $("#code-input").keydown(function (e) {
        if (e.keyCode == 9) {
            e.preventDefault();
            let textArea = $("#code-input");
            // get position of cursor
            let caretPos = document.getElementById("code-input").selectionStart;
            // get text from textarea
            let x = textArea.val();
            // insert tab at cursor position
            textArea.val(x.slice(0, caretPos) + "\t" + x.slice(caretPos));
            // move cursor to after tab position
            textArea.prop('selectionEnd', caretPos + 1);
        }
    })
});


