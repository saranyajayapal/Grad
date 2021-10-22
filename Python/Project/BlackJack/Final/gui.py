from objects import Deck, Hand, Card, Session
import db
import locale as lc
import datetime
from decimal import Decimal
import tkinter as tk
from tkinter import ttk


class Blackjack_frame(ttk.Frame):
    def __init__(self, parent):
        ttk.Frame.__init__(self, parent, padding="10 10 10 10")
        self.parent= parent
        db.connect()
        db.create_session()
        self.session = db.get_last_session()
        self.deck = Deck()
        self.deck.shuffle()
        self.player_hand = Hand()
        self.dealer_hand = Hand(dealer=True)
        self.total_amt = 0
        self.bet_amt = 0
        self.bool_proceed = True
        result = lc.setlocale(lc.LC_ALL, "")
        if result == "C":
            lc.setlocale(lc.LC_ALL, "en_US")
        
        self.pack(fill=tk.BOTH, expand=True)  # these two settings automatically resize the frame itself vertically and horizontally to fill the parent component
        
        
        # Define string objects to be bound in the entry fields
        # Once bound, each object's get() and set() methods can be used to read/write data from/to its bound entry field
        self.money = tk.StringVar()
        self.bet = tk.StringVar()
        self.dealer_card = tk.StringVar()
        self.dealer_points = tk.StringVar()
        self.player_card = tk.StringVar()
        self.player_points = tk.StringVar()
        self.result = tk.StringVar()
                
        # Create two labels, two entry fields, and two buttons
        ttk.Label(self, text="Money:").grid(column=0, row=0, sticky=tk.E)  # E is East, sticky is to align the text with the East side of the grid cell of this label
        ttk.Label(self, text="Bet:").grid(column=0, row=1, sticky=tk.E)
        ttk.Label(self, text="DEALER").grid(column=0, row=2, sticky=tk.E)
        ttk.Label(self, text="Cards:").grid(column=0, row=3, sticky=tk.E)
        ttk.Label(self, text="Points:").grid(column=0, row=4, sticky=tk.E)
        ttk.Label(self, text="YOU").grid(column=0, row=5, sticky=tk.E)
        ttk.Label(self, text="Cards:").grid(column=0, row=6, sticky=tk.E)
        ttk.Label(self, text="Points:").grid(column=0, row=7, sticky=tk.E)
        ttk.Label(self, text="RESULT:").grid(column=0, row=9, sticky=tk.E)
        ttk.Entry(self, width=30,  textvariable=self.money, state="readonly").grid(column=1, row=0,sticky=tk.W)
        ttk.Entry(self, width=30,  textvariable=self.bet).grid(column=1, row=1, sticky=tk.W)
        ttk.Entry(self, width=55,  textvariable=self.dealer_card, state="readonly").grid(column=1, row=3, sticky=tk.W)
        ttk.Entry(self, width=30,  textvariable=self.dealer_points, state="readonly").grid(column=1, row=4, sticky=tk.W)
        ttk.Entry(self, width=55,  textvariable=self.player_card, state="readonly").grid(column=1, row=6, sticky=tk.W)
        ttk.Entry(self, width=30,  textvariable=self.player_points, state="readonly").grid(column=1, row=7, sticky=tk.W)
        ttk.Entry(self, width=55,  textvariable=self.result, state="readonly").grid(column=1, row=9, sticky=tk.W)
        if float(self.session.stop_money) == 0:
            self.money.set(lc.currency("199", grouping=True))
        else:
            self.money.set(lc.currency(self.session.stop_money, grouping=True))
        self.start_money = self.session.stop_money
        self.start_time = datetime.datetime.now()
        self.stop_time = datetime.datetime.now()
        self.prev_session = self.session.sid
        self.bj_buttons()

        self.play_buttons()
        
        # Add padding to all child components
        for child in self.winfo_children():
            child.grid_configure(padx=5, pady=3)
            
    def bj_buttons(self):  # Create a frame to store the two buttons
        buttonFrame= ttk.Frame(self)
        buttonFrame.grid(column=1, row=8, columnspan=2, sticky=tk.W)
        ttk.Button(buttonFrame, text="Hit", command=self.hit).grid(column=0, row=0, padx=1)
        ttk.Button(buttonFrame, text="Stand", command=self.stand).grid(column=1, row=0)

    def play_buttons(self):
        buttonFrame= ttk.Frame(self)
        buttonFrame.grid(column=1, row=10, columnspan=2, sticky=tk.W)
        ttk.Button(buttonFrame, text="Play", command=self.play_game).grid(column=0, row=0, padx=1)
        ttk.Button(buttonFrame, text="Exit", command=self.exit).grid(column=1, row=0)

    def exit(self):
        new_sid = int(self.prev_session)+1
        self.stop_time = datetime.datetime.now()
        session1 = Session(new_sid,str(self.start_time),self.start_money,str(self.stop_time),float(self.total_amt))
        db.add_session(session1)
        self.parent.destroy()

    def btn_enable_disable(self):
        if b1["state"] == "normal":
            b1["state"] = "disabled"
            b2["text"] = "enable"
        else:
            b1["state"] = "normal"
            b2["text"] = "disable"

    ## This function is used to get the bet amount and check the following conditions
    ## check if the bet amt is a valid input that is a float value.
    ## check if bet amt is greater than 5 and not greater than 1000
    ## check if bet amt is lesser than the amount in the money.txt file.
    def get_bet_amt(self):
        try:
            if self.bet.get() != "" and float(self.bet.get()) > 0 and float(self.bet.get()) <= float(self.total_amt):
                self.result.set("")
                self.bet_amt = float(self.bet.get())
                self.bet_amt = Decimal(self.bet_amt)
                self.bet_amt = self.bet_amt.quantize(Decimal("1.00"))
                return self.bet_amt, True
            else:
                self.result.set("You must place a valid bet to play")
                return None, False
        except ValueError:
            self.result.set("Please enter a valid bet amount.")
            return None, False

    def display(self,hand,stand=False):
        i=0
        str_player_cards = ""
        str_dealer_cards = ""
        if hand.dealer and stand is False:
            self.dealer_card.set(str(hand.get_card(1)))
            
        elif hand.dealer and stand is True:
            for card in hand:
                str_dealer_cards = str_dealer_cards + " " + str(card)
            self.dealer_card.set(str_dealer_cards)    
        else:
            for card in hand:
                #print(card)
                str_player_cards = str_player_cards + " " + str(card)
            self.player_card.set(str_player_cards)

    ##This function is used to calculate the money that has to added or deducted from the
    ## player's total amount based on win or lose. If it is a blackjack for player, 1.5 times the bet amount is paid back,
    ## if its normal win for the player then 1 time of the bet amount is paid. If player loses, bet amount is deducted from player total amount.
    def calculate_money(self, win, black_jack, bet_amt, total_amt):
        # total_amt = float(db.get_money())
        if black_jack == True and win == True:
            self.total_amt = total_amt + (bet_amt) + (bet_amt / 2)
        if black_jack == False and win == True:
            self.total_amt = (total_amt + (bet_amt))
        if win == False:
            self.total_amt = total_amt - bet_amt

        self.total_amt = self.total_amt.quantize(Decimal("1.00"))
        # db.write_money(total_amt)
        return self.total_amt

    ##This function gets the hit or stand choice of player and to check if the input provided is valid.                
    def hit(self):
        self.bet_amt, self.bool_proceed = self.get_bet_amt()
        if self.bool_proceed:
            self.player_hand.add_card(self.deck.deal())
            self.display(self.player_hand)
            self.player_points.set(str(self.player_hand.get_point()))
            # self.dealer_points.set(str(self.dealer_hand.get_point(stand=False)))
            # once a card if added to player hand, check if the sum of card value is greater than 21
            # if so player is busted and he loses the bet money.
            if self.player_hand.get_point() > 21:
                self.display(self.dealer_hand,stand=True)
                self.dealer_points.set(str(self.dealer_hand.get_point()))
                self.result.set('you are busted!')
                self.money.set(str(lc.currency(self.calculate_money(False,False,self.bet_amt,self.total_amt))))

            ##after adding card if sum is 21 and dealer point is greater than 17 and less than 21, then
            ##player wins. add 1 time of bet amount to player.
            elif self.player_hand.get_point() == 21 and self.dealer_hand.get_point() >= 17 and self.dealer_hand.get_point() < 21 :
                self.display(self.dealer_hand,stand=True)
                self.dealer_points.set(str(self.dealer_hand.get_point()))
                # self.player_points.set(str(self.player_hand.get_point()))

                self.result.set('Hooray!You win!')
                self.money.set(str(lc.currency(self.calculate_money(True,False,self.bet_amt,self.total_amt))))

            ##after adding card to player and if his points is 21 and dealer point is less than 17
            ## then add more cards to dealer hand until his point reaches 17 or more.
            elif self.player_hand.get_point() == 21 and self.dealer_hand.get_point() < 17:
                while self.dealer_hand.get_point() < 17:
                    self.dealer_hand.add_card(self.deck.deal())
                    if self.dealer_hand.get_point() < 17:
                        self.display(self.dealer_hand,stand=True)
                        self.dealer_points.set(str(self.dealer_hand.get_point()))
                ##after adding card to dealer, if his points also reach 21, then its a tie. same amount retains for player.
                if self.dealer_hand.get_point() == 21:
                    self.display(self.dealer_hand,stand=True)
                    # self.player_points.set(str(self.player_hand.get_point()))
                    self.dealer_points.set(str(self.dealer_hand.get_point()))

                    self.result.set('Draw or Push.')
                    self.money.set(str(lc.currency(self.total_amt)))

                ##after adding card to dealer, if its either greater than 21 or less than 21, player
                ## wins since he already has 21 points. add 1 time of bet amount.
                elif self.dealer_hand.get_point() > 21 or self.dealer_hand.get_point() < 21:
                    self.display(self.dealer_hand,stand=True)
                    # self.player_points.set(str(self.player_hand.get_point()))
                    self.dealer_points.set(str(self.dealer_hand.get_point()))

                    self.result.set('Hooray!You win!')
                    self.money.set(str(lc.currency(self.calculate_money(True,False,self.bet_amt,self.total_amt))))

    ## when user chose stand before he reached 21 and if dealer points is less than 17
    ## add more cards to dealer until he gets 17 or more points.
    def stand(self):
        self.bet_amt, self.bool_proceed = self.get_bet_amt()
        if self.bool_proceed:
            # self.player_points.set(str(self.player_hand.get_point()))
            # self.dealer_points.set(str(self.dealer_hand.get_point()))
            while self.dealer_hand.get_point() < 17:
                self.dealer_hand.add_card(self.deck.deal())
                if self.dealer_hand.get_point() < 17:
                    self.display(self.dealer_hand,stand=True)
                    # self.dealer_points.set(str(self.dealer_hand.get_point()))
            ##after adding card to dealer, if his points are less than or equal to 21 and greater than 17 and greater than
            ##player points then player loses. deduct bet money from player.
            if self.dealer_hand.get_point() <= 21 and self.dealer_hand.get_point() > self.player_hand.get_point():
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Sorry. You lose.')
                self.money.set(str(lc.currency(self.calculate_money(False,False,self.bet_amt,self.total_amt))))

            elif self.dealer_hand.get_point() == self.player_hand.get_point():
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Draw or Push.')
                self.money.set(str(lc.currency(self.total_amt)))

            ##in any other case, the player wins. if dealer is more than 21 or dealer point less than player point.
            else:
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Hooray!You win!')
                self.money.set(str(lc.currency(self.calculate_money(True,False,self.bet_amt,self.total_amt),grouping=True)))

    ##This function handles the main logic of the blackjack game.
    def play_game(self):
        self.dealer_points.set("")
        self.player_points.set("")
        self.player_card.set("")
        self.dealer_card.set("")
        self.result.set("")
        if float(self.money.get().strip("$")) == 0:
            self.money.set("$199.00")

        self.total_amt = Decimal(self.money.get().strip("$"))
        self.total_amt = self.total_amt.quantize(Decimal("1.00"))

        self.bet_amt, self.bool_proceed = self.get_bet_amt()

        if self.bool_proceed:

            self.player_hand = Hand()
            self.dealer_hand = Hand(dealer=True)

            #deck = Deck()

            for i in range(2):
                self.player_hand.add_card(self.deck.deal())
                self.dealer_hand.add_card(self.deck.deal())


            self.display(self.player_hand)
            self.display(self.dealer_hand)
            self.player_points.set(str(self.player_hand.get_point()))
            self.dealer_points.set(str(self.dealer_hand.get_point(stand=False)))
            # to check if dealer or player has a blackjack. or if player has greater than 21, player loses - no need to proceed.
            if self.player_hand.get_point() == 21 and self.dealer_hand.get_point() != 21 :
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Hooray!You win!')
                self.money.set(str(lc.currency(self.calculate_money(True,True,self.bet_amt,self.total_amt))))

            elif self.dealer_hand.get_point() == 21 and self.player_hand.get_point() != 21:
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Sorry.You lose.')
                self.money.set(str(lc.currency(self.calculate_money(False,True,self.bet_amt,self.total_amt))))


            elif self.dealer_hand.get_point() == 21 and self.player_hand.get_point() == 21:
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Draw or Push.')
                self.money.set(str(lc.currency(self.total_amt)))

            elif self.player_hand.get_point() > 21:
                self.display(self.player_hand)
                self.display(self.dealer_hand,stand=True)
                self.player_points.set(str(self.player_hand.get_point()))
                self.dealer_points.set(str(self.dealer_hand.get_point()))

                self.result.set('Sorry.You lose.')
                self.money.set(str(lc.currency(self.calculate_money(False,True,self.bet_amt,self.total_amt))))


if __name__ == "__main__":
    home = tk.Tk()
    home.title("Blackjack")
    #home.geometry("400x320")
    Blackjack_frame(home)
    home.mainloop()
