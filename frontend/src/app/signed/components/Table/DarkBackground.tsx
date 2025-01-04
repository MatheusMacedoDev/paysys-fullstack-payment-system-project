import { ReactNode } from 'react';

interface DarkBackgroundProps {
    children: ReactNode;
}

export default function DarkBackground({ children }: DarkBackgroundProps) {
    return (
        <div className="w-full bg-green-300 text-gray-900 px-[180px] py-[120px] flex flex-col justify-center">
            {children}
        </div>
    );
}
