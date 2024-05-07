import { ReactNode } from 'react';

interface SectionItem {
    sectionItemIcon: ReactNode;
    sectionItemData: string;
}

interface FooterSectionProps {
    sectionTitle: string;
    sectionItems?: Array<SectionItem>;
}

export default function FooterSection({ sectionTitle }: FooterSectionProps) {
    return (
        <section>
            <h3 className="font-semibold text-lg text-gray-800">
                {sectionTitle}
            </h3>
        </section>
    );
}
