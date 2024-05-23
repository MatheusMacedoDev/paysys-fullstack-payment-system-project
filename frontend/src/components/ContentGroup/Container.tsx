import { ReactNode } from 'react';
import { twMerge } from 'tailwind-merge';

interface ContainerProps {
    children: ReactNode;
    className?: string;
}

export default function Container({ children, className }: ContainerProps) {
    const containerDefaultStyle =
        'w-full lg:w-7/12 py-20 lg:py-16 lg:px-24 rounded-3xl lg:shadow-xl flex flex-col items-center gap-y-16';
    const containerStyle = twMerge(containerDefaultStyle, className);

    return <div className={containerStyle}>{children}</div>;
}
