const translations = {
    en: {
        contactDescription: "Share your problems with us.",
        contactUs: "Contact <span>Us</span>",
        infoText: "Don’t Forget to Contact Us",
        infoTextCall: "Call Us",
        infoTextEmail: "Send Email",
        infoTextLocation: "Location",
        fullnamePlaceholder: "Your Fullname",
        emailPlaceholder: "Your Email",
        phonePlaceholder: "Your PhoneNumber",
        subjectPlaceholder: "Subject",
        messagePlaceholder: "Message",
        formButtonText: "Send message"


    },
    az: {
        contactDescription: "Problemlərinizi bizimlə bölüşün.",
        contactUs: "<span>Bizimlə</span> əlaqə saxlayın",
        infoText: "Bizimlə əlaqə saxlamağı unutmayın",
        infoTextCall: "Bizə zəng et",
        infoTextEmail: "Mail göndər",
        infoTextLocation: "Ünvan",
        fullnamePlaceholder: "Sizin tam adınız",
        emailPlaceholder: "Sizin e-poçt ünvanınız",
        phonePlaceholder: "Telefon nömrəniz",
        subjectPlaceholder: "Mövzu",
        messagePlacholder: "Mesaj",
        formButtonText: "Mesajı göndər"


    },
    ru: {
        contactDescription: "Поделитесь с нами своими проблемами.",
        contactUs: "Свяжитесь с <span>нами</span>",
        infoText: "Не забудьте связаться с нами",
        infoTextCall: "Позвоните нам",
        infoTextEmail: "Отправить письмо",
        infoTextLocation: "Местоположение",
        fullnamePlaceholder: "Ваше полное имя",
        emailPlaceholder: "Ваш адрес электронной почты",
        phonePlaceholder: "Ваш номер телефона",
        subjectPlaceholder: "Тема",
        messagePlaceholder: "Сообщение",
        formButtonText:"Отправить сообщение"


    }
};

const urlParams2 = new URLSearchParams(window.location.search);
let selectedLang2 = urlParams2.get('lang') || 'az';


selectedLang2 = selectedLang2.toLowerCase();

if (selectedLang2 != "az" && selectedLang2 != "ru" && selectedLang2 != "en") {
    selectedLang2 = "az";
}



let translation = translations[selectedLang2]
document.getElementById("contactDescription").innerText = translation.contactDescription;
document.getElementById("contactUs").innerHTML = translation.contactUs;
document.getElementById("infoText").innerText = translation.infoText;
document.getElementById("infoTextCall").innerText = translation.infoTextCall;
document.getElementById("infoTextEmail").innerText = translation.infoTextEmail;
document.getElementById("infoTextLocation").innerText = translation.infoTextLocation;
document.getElementById("fullname").setAttribute("placeholder", translation.fullnamePlaceholder);
document.getElementById("email").setAttribute("placeholder", translation.emailPlaceholder);
document.getElementById("phone").setAttribute("placeholder", translation.phonePlaceholder);
document.getElementById("subject").setAttribute("placeholder", translation.subjectPlaceholder);
document.getElementById("message").setAttribute("placeholder", translation.messagePlaceholder);
document.getElementById("formButtonText").innerText = translation.infoTextLocation;
