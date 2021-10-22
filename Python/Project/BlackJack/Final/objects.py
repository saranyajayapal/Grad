import random

class Card:
    def __init__(self, suit, rank,point):
        self.suit = suit
        self.rank = rank
        self.point = point

    def __str__(self):
        return self.rank+self.suit

    def __repr__(self):
        return self.rank+self.suit

class Deck:
    
    def __init__(self):
        suits = ['H', 'D', 'S', 'C']

        rank = ['Ace','2','3','4','5','6','7','8','9','10','Jack','Queen','King']

        self.deck = []
        self.counter = 0
        self.cnt = 0
        
        for s in suits:
            for r in rank:
                if r == 'Jack' or r == 'Queen' or r == 'King':
                    card = Card(s,r,10)
                elif r == 'Ace':
                    card = Card(s,r,11)
                else:
                    card = Card(s,r,int(r))

                self.deck.append(card)
##        for card in self.deck:
##            print(card)  

    def count(self):
        self.cnt = 0
        for card in self.deck:
            self.cnt += 1
        return self.cnt
                

    def shuffle(self):
        random.shuffle(self.deck)

    def deal(self):
        self.card = self.deck.pop()
        self.deck.insert(0,self.card)
        self.counter += 1
        if self.counter == 52:
            self.shuffle()
            self.counter = 0
        return self.card

class Hand:
    def __init__(self, dealer=False):
        self.dealer = dealer
        self.cards = []
        self.val = 0
        self.cnt = 0

    def get_card(self,index):
        return(self.cards[index])

    def add_card(self, card):
        self.cards.append(card)

    def get_point(self, stand=True):
        self.val = 0
        if stand is False:
            self.val = self.cards[1].point
        else:
            for card in self.cards:
                self.val += card.point
        return self.val


    def count(self):
        self.cnt = 0
        for card in self.cards:
            self.cnt += 1
        #print(self.cnt)     
        return self.cnt

     # Implementing iterator:
    def __iter__(self):     # It is called before the very first loop begins.
        self.__index = -1   # This is to initialize __index
        return self

    def __next__(self):
        if self.__index >= len(self.cards)-1:
            raise StopIteration()
        self.__index += 1
        card = self.cards[self.__index]
        return card

class Session:
    def __init__(self, sessionID, startTime, startMoney, stopTime, stopMoney):
        self.sid = sessionID
        self.start_time = startTime
        self.start_money = startMoney
        self.stop_time = stopTime
        self.stop_money = stopMoney

def main():
    print("Cards - Tester")
    print()
    strcard = ""
    # test Deck class
    print("DECK")
    deck = Deck()
    print("Deck created.")
    deck.shuffle()    
    print("Deck shuffled.")
    print("Deck count:", deck.count())
    print()

    # test Hand class
    print("HAND")
    hand = Hand()
    for i in range(4):
        hand.add_card(deck.deal())

    for card in hand:
        strcard = strcard + " " + str(card)
    print(strcard)
    print()

    print("Hand points:", hand.get_point())
    print("Hand count:", hand.count())
    print("Deck count:", deck.count())

if __name__ == "__main__":
    main()
