import React from 'react';
import { useState } from 'react';
import styles from './styles/Commands.module.css';
import { useDispatch, useSelector } from 'react-redux';
import {
  betAsync,
  hitAsync,
  standAsync,
  startNewGameAsync,
  selectGameState,
} from '../context/game-slice';
import { UnknownAction } from '@reduxjs/toolkit';
import { CommandsProps } from '../types/CommandsProps';

const Commands: React.FC<CommandsProps> = ({ isGameOver }) => {
  const [inputValue, setInputValue] = useState('');
  const dispatch = useDispatch();
  const gameState = useSelector(selectGameState);

  const handleDeal = () => {
    dispatch(betAsync(Number(inputValue)) as unknown as UnknownAction);
  };

  const handleHit = () => {
    dispatch(hitAsync() as unknown as UnknownAction);
  };

  const handleStand = () => {
    dispatch(standAsync() as unknown as UnknownAction);
  };

  const handleNewRound = () => {
    dispatch(startNewGameAsync() as unknown as UnknownAction);
  };

  const handleInputChange = (e) => {
    setInputValue(e.target.value);
  };

  return (
    <div className={styles.commands}>
      <div className={styles.bet}>
        <div className={styles.amountContainer}>
          <div className={styles.amountBox}>
            <p className={styles.balanceText}>Balance:</p>
            <div className={styles.amount}>
              {gameState.player && <div>{gameState.player.balance}</div>}
            </div>
          </div>
        </div>
        <input
          type="number"
          max={gameState.player.balance}
          min={10}
          className={styles.input}
          onChange={handleInputChange}
          value={inputValue}
        />
        <button
          className={styles.button}
          onClick={handleDeal}
          disabled={isGameOver}
        >
          Bet
        </button>
      </div>
      <div className={styles.hitstand}>
        {isGameOver ? (
          <button className={styles.button} onClick={handleNewRound}>
            New Round
          </button>
        ) : (
          <>
            <button className={styles.button} onClick={handleHit}>
              Hit
            </button>
            <button className={styles.button} onClick={handleStand}>
              Stand
            </button>
          </>
        )}
      </div>
    </div>
  );
};

export default Commands;
