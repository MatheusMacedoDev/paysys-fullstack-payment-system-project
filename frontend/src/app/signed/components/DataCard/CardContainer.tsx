import { ReactNode } from 'react';
import { twMerge } from 'tailwind-merge';

interface CardContainerProps {
    children: ReactNode;
    className?: string;
}

export default function CardContainer({
    children,
    className
}: CardContainerProps) {
    const containerDefaultStyle =
        'border border-green-900 border-2 rounded-xl text-green-300 flex flex-col items-center';
    const containerMergedStyle = twMerge(containerDefaultStyle, className);

    return <div className={containerMergedStyle}>{children}</div>;
}
