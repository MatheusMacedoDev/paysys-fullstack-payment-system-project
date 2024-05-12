import { ReactNode } from 'react';
import { twMerge } from 'tailwind-merge';

interface ContainerProps {
    children: ReactNode;
    className?: string;
}

export default function Container({ children, className }: ContainerProps) {
    const originalClassName =
        'flex gap-y-16 flex-col lg:flex-row lg:justify-between lg:gap-x-28 w-full';
    const mergedClassName = twMerge(originalClassName, className);

    return <div className={mergedClassName}>{children}</div>;
}
