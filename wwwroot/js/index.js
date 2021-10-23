
var defaultCode = "public class Solution {\n\tpublic static int Algorithm(int n)\n\t{\n\t\t//Enter code here\n\t\treturn 0;\n\t}\n}";

let rowNum = 1;


$(document).ready(function () {
    /*
     * set the default code for c#
     */
    $("#code-input").val(defaultCode);

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

    /*
     * function for reseting textarea to default class and method headers
     */
    $("#reset").click(function () {
        $("#code-input").val(defaultCode);
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


