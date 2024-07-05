import { Company } from "./CompanyInterface";

export interface AddCompanyFormProps {
    onCompanyAdded: (company: Company) => void;
}