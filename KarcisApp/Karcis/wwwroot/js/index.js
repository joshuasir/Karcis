
async function query_getTicket() {
    const response = await fetch("../Home/Ticket", {
        method: "GET"
    });
    const data = await response.text();
    return data;
}

async function loadTickets() {

    const data = await query_getTicket();

    document.getElementById("mainTicketContainer").innerHTML = data;

    $(".buyButton").on("click", function () {
        $(".ticketAmount").css("display", "block");
        $("#cartContainer").css("display", "flex");
        $(".ticketAmount").on("input", function () {
            let min = parseInt($(this).next().next().val());
            min = ((min >= 30) ? 30 : min);
            
            let num = parseInt($(this).val());
            $(this).val(((num >= min) ? min : num));
        });
    });

    $("#cartContainer").on("click", await async function () {

        let ticketQty = [
            ["Platinum",
                document.getElementById("inputPlatinum"),
                document.getElementById("inputPricePlatinum")],
            ["Golden",
                document.getElementById("inputGolden"),
                document.getElementById("inputPriceGolden")],
            ["Silver",
                document.getElementById("inputSilver"),
                document.getElementById("inputPriceSilver")],
            ["Bronze",
                document.getElementById("inputBronze"),
                document.getElementById("inputPriceBronze")]
        ]

        var Booking = {};
        Booking.EventName = document.getElementById("EventName").innerHTML;
        Booking.Tickets = []
        var check = 0;
        for (let i = 0; i < 4; i++) {
            if (ticketQty[i][1] == null) {
                continue;
            }
            Booking.Tickets.push({
                TicketType: ticketQty[i][0],
                Qty: parseInt(ticketQty[i][1].value),
                TicketPrice: parseInt(ticketQty[i][2].value)
            });
            check += ticketQty[i][1].value
        }
        if (check == 0) {
            alert("Please Enter a valid Quantity");
            return;
        }

        const response = await fetch("../Home/Summary", {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(Booking),
        });
        if (response.redirected) {
            return window.location.replace("/Registry/Login");
        }
        const summary = await response.text();
        document.getElementById("bookingSummary").innerHTML = summary;
        $("#bookingSummary").css("display", "flex");


    });
}
loadTickets();
function closeBooking() {
    $("#bookingSummary").css("display", "none");
    loadTickets();
}
$("#eventContainer").css("height", window.innerHeight - $("#eventContainer").offset().top);
$("#previousPage").css("top", window.innerHeight - $("#eventContainer").height());

$(window).resize(function () {
    $("#eventContainer").css("height", window.innerHeight - $("#eventContainer").offset().top);
    $("#previousPage").css("top", window.innerHeight - $("#eventContainer").height());
});


function closeBookingSummary() {
    $("#bookingSummary").css("display", "none");
}

function closeBookingSummary() {
    $("#bookingSummary").css("display", "none");
}