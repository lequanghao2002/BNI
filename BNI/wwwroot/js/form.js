var currentFormIndex = 1;
var totalForms = 6; // Số lượng tổng cộng các form

function moveToNextForm() {
    if (currentFormIndex < totalForms) {
        var currentForm = document.getElementById('form' + currentFormIndex);
        currentForm.classList.remove('active');
        currentFormIndex++;
        var nextForm = document.getElementById('form' + currentFormIndex);
        nextForm.classList.add('active');
        updateButtons();
    }
}

function moveToPrevForm() {
    if (currentFormIndex > 1) {
        var currentForm = document.getElementById('form' + currentFormIndex);
        currentForm.classList.remove('active');
        currentFormIndex--;
        var prevForm = document.getElementById('form' + currentFormIndex);
        prevForm.classList.add('active');
        updateButtons();
    }
}

function updateButtons() {
    var prevButton = document.querySelector('.button-prev');
    var nextButton = document.querySelector('.button-next');

    if (currentFormIndex === 1) {
        prevButton.disabled = true;
    } else {
        prevButton.disabled = false;
    }

    if (currentFormIndex === totalForms) {
        nextButton.disabled = true;
    } else {
        nextButton.disabled = false;
    }
    const tabItems = document.querySelectorAll("#form-builder-tab-list .tab-item");
    tabItems.forEach(function (tabItem, index) {
        if (index + 1 === currentFormIndex) {
            tabItem.querySelector(".tab-label").classList.remove("hIfQrc");
            tabItem.querySelector(".tab-label").classList.add("ipSphO");
        } else {
            tabItem.querySelector(".tab-label").classList.remove("ipSphO");
            tabItem.querySelector(".tab-label").classList.add("hIfQrc");
        }
    });
}
document.addEventListener("DOMContentLoaded", function () {
    // Lấy danh sách các tab item
    const tabItems = document.querySelectorAll("#form-builder-tab-list .tab-item");

    // Lặp qua mỗi tab item để thêm sự kiện click
    tabItems.forEach(function (tabItem, index) {
        tabItem.addEventListener("click", function () {
            // Ẩn tất cả các form
            document.querySelectorAll(".form").forEach(function (form) {
                form.classList.remove("active");
            });

            // Lấy id của form tương ứng từ thuộc tính data-target
            var targetFormId = this.getAttribute("data-target");
            // Hiển thị form tương ứng bằng cách thêm lớp 'active'
            document.getElementById(targetFormId).classList.add("active");

            // Cập nhật currentFormIndex
            currentFormIndex = index + 1;
        });
    });
});
document.addEventListener("DOMContentLoaded", function () {
    // Lấy danh sách các tab item
    const tabItems = document.querySelectorAll("#form-builder-tab-list .tab-item");

    // Lặp qua mỗi tab item để thêm sự kiện click
    tabItems.forEach(function (tabItem) {
        tabItem.addEventListener("click", function () {
            // Xóa lớp 'ipSphO' và thêm lớp 'hIfQrc' cho tất cả các tab label
            document.querySelectorAll("#form-builder-tab-list .tab-label").forEach(function (label) {
                label.classList.remove("hIfQrc");
                label.classList.add("ipSphO");
            });

            // Xóa lớp 'hIfQrc' và thêm lớp 'ipSphO' cho tab label của tab item đang được click
            this.querySelector(".tab-label").classList.remove("ipSphO");
            this.querySelector(".tab-label").classList.add("hIfQrc");
        });
    });
});
document.addEventListener("DOMContentLoaded", function () {
    document.querySelector('.button-next').addEventListener("click", moveToNextForm);
    document.querySelector('.button-prev').addEventListener("click", moveToPrevForm);

    updateTabsAndButtons();
});


