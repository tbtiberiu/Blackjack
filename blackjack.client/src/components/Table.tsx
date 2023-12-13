import React, { useContext, useEffect, useState } from "react";
import styles from "./styles/Table.module.css";
import Hand from "./Hand";
import Commands from "./Commands";
import { Suits } from "../enums/suits";
import { GameContext } from "../contexts/GameContext";

const Table: React.FC = () => {
  const { gameState } = useContext(GameContext);
  const [playerHand, setPlayerHand] = useState<any>([]);
  const [dealerHand, setDealerHand] = useState<any>([]);

  useEffect(() => {
    handleHands();
  }, [gameState]);

  const handleHands = () => {
    if (gameState) {
      if (gameState.playerHand) {
        let translatedCards = gameState.playerHand.cards.map((card) =>
          translateCard(card)
        );
        setPlayerHand(translatedCards);
      }

      if (gameState.dealerHand) {
        let translatedCards = gameState.dealerHand.cards.map((card) =>
          translateCard(card)
        );
        setDealerHand(translatedCards);
      }
    }
  };

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
      formattedCardValue = "A";
    } else if (cardValue === 12) {
      formattedCardValue = "J";
    } else if (cardValue === 13) {
      formattedCardValue = "Q";
    } else if (cardValue === 14) {
      formattedCardValue = "K";
    } else {
      formattedCardValue = cardValue.toString();
    }

    return {
      value: formattedCardValue,
      suit: formattedCardSuit,
      hidden: false,
    };
  };

  return (
    <>
      <div className={styles.table}>
        <div className={styles.hands}>
          <Hand cards={dealerHand} />

          <Hand cards={playerHand} />
        </div>

        <div className={styles.deck}></div>
      </div>
      <div className={styles.commands}>
        <Commands />
      </div>
    </>
  );
};

export default Table;
