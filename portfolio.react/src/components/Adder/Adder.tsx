import React from 'react';

interface Props {
  num1: number,
  num2: number
}

function Add(num1: number, num2: number): number {
  return num1 + num2;
}

const Adder: React.FC<Props> = (props: Props) => (
  <div>
    I can add!
    <hr />
    {props.num1} + {props.num2} = {Add(props.num1, props.num2)}
  </div>
);

export default Adder;
