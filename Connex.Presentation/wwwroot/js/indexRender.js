const translations = {
    en: {
        sliderTitle: "Welcome to Our Platform",
        sliderSubtitle: "We offer great services",
        aboutDescription: "Experience the best with us.",
        readMore: "Read More",
        ourServices: "Our <span>Services</span>",
        aboutUs: "About <span>Us</span>",
        whyChooseUs: "Why Choose <span>Us</span>",
        ourProjects: "Our <span>Projects</span>",
        ourProjectsDescription: "We are professionals in our work.",
        certificates: "Our Certifications and <span>Licenses</span>",
        certificatesDescription: "Professionalism is our business",
        ReadMoreBtn: "Read More"


    },
    az: {
        sliderTitle: "Platformamıza Xoş Gəlmisiniz",
        sliderSubtitle: "Biz böyük xidmətlər təklif edirik",
        aboutDescription: "Bizimlə ən yaxşı təcrübəni yaşayın.",
        readMore: "Daha Ətraflı",
        ourServices: "Xidmətlərimiz",
        aboutUs: "Haqqımızda",
        whyChooseUs: "Niyə <span>Bizi Seçməlisiniz?</span>",
        ourProjects: "Layihələrimiz",
        ourProjectsDescription: "İşimizin peşəkarıyıq.",
        certificates: " Sertifikat və <span>Lisenziyalarımız</span>",
        certificatesDescription: "Peşəkarlıq bizim işimizdir.",
        ReadMoreBtn: "Daha çox"

    },
    ru: {
        sliderTitle: "Добро пожаловать на нашу платформу",
        sliderSubtitle: "Мы предлагаем отличные услуги",
        aboutDescription: "Испытайте лучшее с нами.",
        readMore: "Читать далее",
        ourServices: "Наши <span>услуги</span>",
        aboutUs: "О <span>нас</span>",
        whyChooseUs: "Почему <span>выбирают нас</span>",
        ourProjects: "Наши <span>Проекты</span>",
        ourProjectsDescription: "Мы профессионалы своего дела.",
        certificates: "Наши сертификаты и <span>лицензии</span>",
        certificatesDescription: "Профессионализм – наша работа",
        ReadMoreBtn: "Читать далее"
    }
};

const urlParams2 = new URLSearchParams(window.location.search);
let selectedLang2 = urlParams2.get('lang') || 'az';


selectedLang2 = selectedLang2.toLowerCase();

if (selectedLang2 != "az" && selectedLang2 != "ru" && selectedLang2 != "en") {
    selectedLang2 = "az";
}



let translation = translations[selectedLang2]

document.getElementById("ourServices").innerHTML = translation.ourServices;
document.getElementById("sliderSubtitle").innerText = translation.sliderSubtitle;
document.getElementById("readMore").innerText = translation.readMore;
document.getElementById("aboutUs").innerHTML = translation.aboutUs;
document.getElementById("aboutDescription").innerText = translation.aboutDescription;
document.getElementById("whyChooseUs").innerHTML = translation.whyChooseUs;
document.getElementById("ourProjects").innerHTML = translation.ourProjects;
document.getElementById("ourProjectsDescription").innerHTML = translation.ourProjectsDescription;
document.getElementById("certificates").innerHTML = translation.certificates;
document.getElementById("certificatesDescription").innerHTML = translation.certificatesDescription;
document.querySelectorAll("#ReadMoreBtn").forEach(btn => btn.innerHTML = translation.ReadMoreBtn);

