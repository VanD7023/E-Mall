var dosyalar = [];
var imageLoader = document.getElementById('picupload');
imageLoader.addEventListener('change', ImageUpload, false);
function ImageUpload() {
    dosyalar = [];
  var files = event.target.files;
  var output = document.getElementById("media-list");
  for (var i = 0; i < files.length; i++) {
    var file = files[i];
    dosyalar.push($(this).get(0).files[i].name);
      if (file.type.match('image')) {
      var picReader = new FileReader();
      picReader.fileName = file.name;
      picReader.addEventListener("load", function(event) {
        var picFile = event.target;
        var div = document.createElement("li");
          div.innerHTML = "<img src='" + picFile.result + "'" +
          "title='" + picFile.name + "'/><div  class='post-thumb'><div class='inner-post-thumb'><a href='javascript:void(0);' data-id='" + event.target.fileName + "' class='remove-pic' onclick='remove()'><i class='fa fa-times' aria-hidden='true'></i></a><div></div>";
          $("#media-list").prepend(div);
      });
      picReader.readAsDataURL(file);
    }
  }
}
$('body').on('click', '.remove-pic', function() {
    console.log("remove")
    $(this).parent().parent().parent().remove();
    var removeItem = $(this).attr('id');
    var yet = dosyalar.indexOf(removeItem);
    if (yet != -1) {
        names.splice(yet, 1);
    }
});
