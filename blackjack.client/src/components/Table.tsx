import React from 'react';
import styles from './styles/Table.module.css';
import { useState, useEffect } from 'react';
import translateCard from '../utils/translateCards';
import Hand from './Hand';
import Commands from './Commands';
import { useDispatch, useSelector } from 'react-redux';
import {
  checkWinnerAsync,
  selectGameState,
  selectWinnerState,
} from '../context/game-slice';
import { UnknownAction } from '@reduxjs/toolkit';

const Table: React.FC = () => {
  const dispatch = useDispatch();
  const gameState = useSelector(selectGameState);
  const winnerState = useSelector(selectWinnerState);
  const [playerHand, setPlayerHand] = useState<any>([]);
  const [dealerHand, setDealerHand] = useState<any>([]);

  useEffect(() => {
    handleHands();
    dispatch(checkWinnerAsync() as unknown as UnknownAction);
    console.log('checkWinner from table :', winnerState);
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
          translatedCards[0] = {
            ...translatedCards[0],
            hidden: gameState.dealerHand.isHidden,
          };
        }

        setDealerHand(translatedCards);
      }
    }
  };

  const showMessage =
    winnerState === 'Dealer wins' ||
    winnerState === 'Player wins' ||
    winnerState === 'Tie';

  return (
    <>
      <div className={styles.container}>
        {showMessage && <div className={styles.winner}> {winnerState} </div>}
        <div className={styles.table}>
          <div className={styles.hands}>
            <Hand cards={dealerHand} />
            <Hand cards={playerHand} />
          </div>
          <div className={styles.deck}></div>
        </div>
      </div>
      <div className={styles.commands}>
        <Commands isGameOver={showMessage} />
      </div>
    </>
  );
};

export default Table;
