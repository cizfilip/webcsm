function openIdUrl(site) {
    var value = "";
    var autoClick = false;

    if (site == "google") {
        value = "https://www.google.com/accounts/o8/id";
        autoClick = true;
    }

    if (value) {
        var jText = $("#openid_identifier");
        jText.val(value)
            .focus();
        if (autoClick)
            $("#btnGoogleLogin").trigger("click");
    }
}