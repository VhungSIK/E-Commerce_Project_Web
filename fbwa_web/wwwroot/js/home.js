document.addEventListener("DOMContentLoaded", function () {
    let index = 0;
    const slides = document.querySelectorAll(".slide");
    const totalSlides = slides.length;

    function showSlide(idx) {
        slides.forEach((slide, i) => {
            slide.style.display = i === idx ? "block" : "none";
        });
    }

    function nextSlide() {
        index = (index + 1) % totalSlides;
        showSlide(index);
    }

    setInterval(nextSlide, 4000); // Change slide every 4 seconds
    showSlide(index); // Initial call to display the first slide
});
