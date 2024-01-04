import React from "react";
import styles from "./styles/Table.module.css";
import { useState, useEffect } from "react";
import translateCard from "../utils/translateCards";
import Hand from "./Hand";
import Commands from "./Commands";
import { useDispatch, useSelector } from "react-redux";
import {
  checkWinnerAsync,
  selectGameState,
  selectWinnerState,
  startNewGameAsync,
} from "../context/game-slice";
import { UnknownAction } from "@reduxjs/toolkit";
import { searchForWorkspaceRoot } from "vite";

const Table: React.FC = () => {
  const dispatch = useDispatch();
  const gameState = useSelector(selectGameState);
  const winnerState = useSelector(selectWinnerState);
  const [playerHand, setPlayerHand] = useState<any>([]);
  const [dealerHand, setDealerHand] = useState<any>([]);

  useEffect(() => {
    handleHands();
    dispatch(checkWinnerAsync() as unknown as UnknownAction);
    console.log("checkWinner from table :", winnerState);
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

        if (translatedCards.length > 0) {
         translatedCards[0] = { ...translatedCards[0], hidden: true };
        }

        setDealerHand(translatedCards);
      }
    }
  };

  useEffect(() => {
    dispatch(startNewGameAsync() as unknown as UnknownAction);
  }, [winnerState === "Dealer wins" || winnerState === "Player wins" || winnerState === "Tie" ]);

  const showMessage =
    winnerState === "Dealer wins" || winnerState === "Player wins" || winnerState === "Tie";

  return (
    <>
      {showMessage && <div className={styles.winner}> {winnerState} </div>}
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
