import { ReactNode } from 'react';
import { twMerge } from 'tailwind-merge';

interface ContainerProps {
    children: ReactNode;
    className?: string;
}

export default function Container({ children, className }: ContainerProps) {
    const containerDefaultStyle =
        'w-full lg:w-10/12 xl:w-7/12 py-20 lg:py-16 lg:px-24 rounded-3xl flex flex-col items-center gap-y-12 lg:shadow-[3px_3px_10px_0_rgba(0,0,0,0.2)]';
    const containerStyle = twMerge(containerDefaultStyle, className);

    return <div className={containerStyle}>{children}</div>;
}
