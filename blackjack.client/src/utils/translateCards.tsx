import { Suits } from '../enums/suits';
const translateCard = (card: { suit: number; rank: number }) => {
  let cardValue = card.rank;
  let cardSuit = card.suit;
  let formattedCardValue: string;
  let formattedCardSuit: Suits;

  if (cardSuit === 0) {
    formattedCardSuit = Suits.Spades;
  } else if (cardSuit === 1) {
    formattedCardSuit = Suits.Hearts;
  } else if (cardSuit === 2) {
    formattedCardSuit = Suits.Diamonds;
  } else {
    formattedCardSuit = Suits.Clubs;
  }

  if (cardValue === 11) {
    formattedCardValue = 'A';
  } else if (cardValue === 12) {
    formattedCardValue = 'J';
  } else if (cardValue === 13) {
    formattedCardValue = 'Q';
  } else if (cardValue === 14) {
    formattedCardValue = 'K';
  } else {
    formattedCardValue = cardValue.toString();
  }

  return {
    value: formattedCardValue,
    suit: formattedCardSuit,
    hidden: false,
  };
};

export default translateCard;
