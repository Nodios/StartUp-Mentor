var validFileTypes = [".avi", ".mpeg", ".mp4"];
function ValidateFile() {
    var file = document.getElementById("questionFile");
    var path = file.value;
    var ext = path.substring(path.lastIndexOf(".") + 1, path.length),toLowerCase();
}