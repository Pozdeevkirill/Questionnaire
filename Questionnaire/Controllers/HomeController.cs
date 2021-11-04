using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Questionnaire.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Questionnaire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static string token { get; set; } = "";//Укажите токен бота
        private static long adminId { get; set; } = ;//Укажите id пользователя, которому бот будет отсылать результаты
        private static TelegramBotClient client;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AnswerViewModel model, string first, string second, string thrid)
        {
            if (model != null)
            {
                model.First = first;
                model.Second = second;
                model.Thrid = thrid;
                SendMsg(model);
                return Redirect("/Home/Ready");
            }
            return View();
        }

        private async void SendMsg(AnswerViewModel model)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            string first;
            string second;
            string thrid;
            switch (model.First)
            {
                case "1":
                    first = "У меня упакованная шапка профиля в Instagram. По ней понятно чем я занимаюсь и чем могу быть полезен(а). Есть увеличенная кнопка подписки и доп.описание в адресе.";
                    break;
                case "2":
                    first = "Мои хайлайтс оформленны в едином стиле и есть основные рубрики. Кейсы, отзывы, продукты, бесплатные материалы и другие.";
                    break;
                case "3":
                    first = "У моей ленты есть единый стиль, я использую бесшовные карусели для контентных постов. Я использую надписи на фото для навигации подписчиков.";
                    break;
                case "4":
                    first = "У меня нет трудностей с написанием постов. Я знаю как искать темы для постов, как правильно строить структуры написания и как вовлекать аудиторию.";
                    break;
                case "5":
                    first = "У меня есть фирменный стиль сторис и шаблоны под все рубрики.";
                    break;
                case "6":
                    first = "У меня есть контент план для сторис и ленты, где регулярно выходит контент.";
                    break;
                case "7":
                    first = "У меня есть главная страница сайта с описанием всех услуг, кейсов и другими материалами.";
                    break;
                case "8":
                    first = "У меня есть упокованные кейсы на сайте. Я описываю каждый кейс и публикую в виде страниц на сайте. Есть четкая структура описания кейсов по которой их собираю.";
                    break;
                default:
                    first = null;
                    break;
            }
            switch (model.Second)
            {
                case "1":
                    second = "У меня упакованная шапка профиля в Instagram. По ней понятно чем я занимаюсь и чем могу быть полезен(а). Есть увеличенная кнопка подписки и доп.описание в адресе.";
                    break;
                case "2":
                    second = "Я привлекаю подписчиков в Instagram через торгетерованную рекламу и рекламу у блогеров.";
                    break;
                case "3":
                    second = "У меня есть автоворонка продаж в мессенджерах, которую я использую для основного привлечения клиентов.";
                    break;
                case "4":
                    second = "Я провожу вебинары, знаю как собирать продающие презентации и вебинарные воронки.";
                    break;
                case "5":
                    second = "Я знаю свою целевую аудиторию и смыслы о моем бренде.";
                    break;
                case "6":
                    second = "Я провожу запуски в Instagram своих продуктов и услуг.";
                    break;
                case "7":
                    second = "У меня есть рекламные креативы для торгетированной рекламы с высокими показателями CTR.";
                    break;
                case "8":
                    second = "Я работаю с реторгетингом через тарегтированную рекламу в Facebook и Instagram.";
                    break;
                default:
                    second = null;
                    break;
            }
            switch (model.Thrid)
            {
                case "1":
                    thrid = "У меня есть система для учета клиентов.";
                    break;
                case "2":
                    thrid = "У меня есть скрипты продаж.";
                    break;
                case "3":
                    thrid = "У меня есть продуктовая матрица и механики продаж.";
                    break;
                case "4":
                    thrid = "Я использую рассрочки для клиентов.";
                    break;
                case "5":
                    thrid = "У меня есть продукт для ключевого этапа ворнки продаж.";
                    break;
                case "6":
                    thrid = "У меня есть опыт продаж по телефону и в переписке.";
                    break;
                case "7":
                    thrid = "У меня есть трипоаер для продажи на входе в воронку.";
                    break;
                case "8":
                    thrid = "Я работаю с реторгетингом через тарегтированную рекламу в Facebook и Instagram.";
                    break;
                default:
                    thrid = null;
                    break;
            }
            await client.SendTextMessageAsync(adminId, text: $"Новый результат опроса:\nФамилия имя: {model.Name}\n" +
                $"Телефон: {model.Phone}" +
                $"Почта: {model.Email}\n" +
                $"Город: {model.City}\n" +
                $"Деятельность: {model.Activity}\n" +
                $"Среднемесячный доход: {model.AVGIncome}\n" +
                $"Что будет для вас наилучшим результатом после прохождения разбора?: {model.BestResult}\n" +
                $"Назовите свою основную трудность на данный момент:* {model.Difficulty}\n" +
                $"Ваши вопросы: {model.Questions}\n" +
                $"Instagram: {model.Instagram}\n" +
                $"Сайт: {model.Site}\n" +
                $"ТОЧКИ А-Б\n" +
                $"Точка А. Какой средний доход в месяц сейчас?: {model.PointA}\n" +
                $"Точка Б. К какому дохудо хочешь прийти? (В т.ч 3 мес): {model.PointB}\n" +
                $"Гипотеза № 1: {model.Hypothesis1}\n" +
                $"Гипотеза № 2: {model.Hypothesis2}\n" +
                $"Гипотеза № 3: {model.Hypothesis3}\n" +
                $"Гипотеза № 4: {model.Hypothesis4}\n" +
                $"Гипотеза № 5: {model.Hypothesis5}\n" +
                $"Упаковка: {first}\n" +
                $"Маркетинг: {second}\n" +
                $"Продажи: {thrid}");
            client.StopReceiving();
        }

        public IActionResult Ready()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
