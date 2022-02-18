var navbar = document.querySelector('nav')
window.addEventListener('scroll', function () {
    if (window.pageYOffset > 100) {
        navbar.classList.add('background-navbar', 'shadow');
    } else {
        navbar.classList.remove('background-navbar', 'shadow')
    }
});