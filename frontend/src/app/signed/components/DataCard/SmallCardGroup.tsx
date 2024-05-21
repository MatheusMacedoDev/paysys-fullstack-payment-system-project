import { ReactNode } from 'react';
import { twMerge } from 'tailwind-merge';

interface SmallCardGroupProps {
    children: ReactNode;
    className?: string;
}

export default function SmallCardGroup({
    children,
    className
}: SmallCardGroupProps) {
    const defaultGroupStyle =
        'flex flex-col lg:flex-row flex-wrap gap-12 justify-center';
    const mergedGroupStyle = twMerge(defaultGroupStyle, className);

    return <div className={mergedGroupStyle}>{children}</div>;
}
