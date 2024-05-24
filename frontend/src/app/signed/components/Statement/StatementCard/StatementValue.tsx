import { twMerge } from 'tailwind-merge';

export interface StatementValueProps {
    valueAmount: number;
}

const BRL = new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
});

export default function StatementValue({ valueAmount }: StatementValueProps) {
    let valueStyle = 'font-bold text-base';

    if (valueAmount < 0) {
        valueStyle = twMerge(valueStyle, 'text-red');
    } else {
        valueStyle = twMerge(valueStyle, 'text-green-900');
    }

    return <span className={valueStyle}>{BRL.format(valueAmount)}</span>;
}
