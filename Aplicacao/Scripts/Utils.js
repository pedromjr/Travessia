function ConvertDateTimeToDate(dateTime) {
    var jsDate = new Date(dateTime);

    return jsDate.getDate() + "/" + (jsDate.getMonth() + 1).PadLeft(2, '0') + "/" + jsDate.getFullYear();
}

function ConvertDateTimeToDateAndTime(dateTime) {
    var jsDate = new Date(dateTime);

    return jsDate.getDate()
        + "/"
        + (jsDate.getMonth() + 1).PadLeft(2, '0')
        + "/"
        + jsDate.getFullYear()
        + " "
        + jsDate.getHours().PadLeft(2, '0')
        + ":"
        + jsDate.getMinutes().PadLeft(2, '0')
        + ":"
        + jsDate.getSeconds().PadLeft(2, '0');
}

function ServerTrue(value) {
    return value === "True";
}

Number.prototype.PadLeft = function (n, str) {
    return Array(n - String(this).length + 1).join(str || '0') + this;
}