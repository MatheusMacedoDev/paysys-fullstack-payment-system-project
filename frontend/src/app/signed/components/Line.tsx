import { twMerge } from 'tailwind-merge';

interface LineProps {
    className?: string;
}

export default function Line({ className }: LineProps) {
    const lineDefaultStyle = 'w-full h-[1px] bg-green-300';
    const lineStyle = twMerge(lineDefaultStyle, className);

    return <div className={lineStyle} />;
}
