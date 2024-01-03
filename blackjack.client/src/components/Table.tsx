import React, { useEffect } from "react";
import styles from "./styles/Table.module.css";
import { useState } from "react";
import translateCard from "../utils/translateCards";
import Hand from "./Hand";
import Commands from "./Commands";
import { useDispatch, useSelector } from "react-redux";
import { selectGameState } from "../context/game-slice";

const Table: React.FC = () => {
  const dispatch = useDispatch();
  const gameState = useSelector(selectGameState);
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
