import React from 'react';
import { useSpring, animated } from 'react-spring';

const AnimatedNumber = ({ number, decimals = 0 }) => {
  const props = useSpring({ number, from: { number: 0 }, config: { duration: 1000 } });

  return <animated.span>{props.number.to(n => n.toFixed(decimals))}</animated.span>;
};

export default AnimatedNumber;
