$.cloudinary.config({ cloud_name: "tantadamcloud", api_key: "382595625523566" });

$(function () {
    if ($.fn.cloudinary_fileupload !== undefined) {
        $("input.cloudinary-fileupload[type=file]").cloudinary_fileupload();
    }
});

$(document).ready(function () {
    $(".dynamic_image").cloudinary({
        width: 115, height: 135, crop: 'thumb', gravity: 'faces', radius: 20
    });
});
