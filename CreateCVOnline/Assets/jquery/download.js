
$(document).ready(function(){ 
    $('#download').click(function () {
        var pdf = new jsPDF('p', 'pt', [1280,4000]);
        pdf.addHTML(document.body, function () {
            pdf.save('CV.pdf');
        });
    })
});